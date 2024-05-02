import { Box, Button, Card, CardBody, CardFooter, CardHeader, Center, CloseButton, Container, Flex, FormLabel, HStack, Heading, Image, Input, List, ListItem, Tag, TagCloseButton, TagLabel, Text } from "@chakra-ui/react"
import { Link, useNavigate } from "react-router-dom"
import { CancelAlert, EventModal, LoginButton, LoginInput } from "../components"
import { IoCheckmarkCircleOutline } from '../assets/icons'
import * as Yup from 'yup'
import { useEffect, useState } from "react"
import avatar from '../assets/avatar.png'
import axios from "axios"

const ContractorForm = () => {
    const [isSubmitting, setIsSubmitting] = useState(false)
    const [errors, setErrors] = useState({})
    const [values, setValues] = useState({ socialName:'', web:'', cuit: 0 })
    const [selectedExperts, setSelectedExperts] = useState([])
    const [isExpertModalOpen, setIsExpertModalOpen] = useState(false)
    const [expertOptions, setExpertOptions] = useState([]) 
    const [imageUrl, setImageUrl] = useState('') 
    const navigate = useNavigate()
    
    const validationSchema = Yup.object().shape({        
        socialName: Yup.string().min(3, 'Mínimo 3 caractares').max(30, 'Máximo 30 caracteres').required('Campo requerido'),
        web: Yup.string().min(3, 'Mínimo 3 caractares').max(30, 'Máximo 30 caracteres').required('Campo requerido'),        
        cuit: Yup.number().min(5, 'Mínimo 5 caractares').required('Campo requerido')        
    })
    useEffect(() => {
        const fetchExpertOptions = async () => {
          try {        
            const response = await axios.get('https://www.eventplanner.somee.com/api/Vocation/GetAll')
            console.log(response.data)
            setExpertOptions(response.data)
          } catch (error) {
            console.error('Error al obtener opciones de expertos:', error.message)
          }
        }
        fetchExpertOptions()
      }, []) 

    const handleExpertOptionClick = (expertOption) => {
        if (!selectedExperts.some(expert => expert.id === expertOption.id)) {
        setSelectedExperts([...selectedExperts, expertOption])        
        handleExpertModalClose()        
        } 
    }    
    const handleExpertModalOpen = () => {
        setIsExpertModalOpen(true)
    }
    const handleExpertModalClose = () => {
        setIsExpertModalOpen(false)
    }  
    const handleChange = (event) => {
        const { name, value } = event.target
        setValues({
        ...values,
        [name]: value
        })
    }
    const handleTagRemove = (indexToRemove) => {
        setSelectedExperts(selectedExperts.filter((_, index) => index !== indexToRemove))
    } 
    const handleImgSubmit = async () => {
      const imageInput = document.querySelector('input[type="file"]')
      if (!imageInput || !imageInput.files || imageInput.files.length === 0) {
          console.error('No se ha seleccionado ningún archivo')
          return
      }  
      const imageUpload = imageInput.files[0]      
      try {          
          const formData = new FormData()
          formData.append('file', imageUpload)  
          const response = await axios.post('https://www.eventplanner.somee.com/api/ProfileImage', formData, {
              headers: {
                  'Content-Type': 'multipart/form-data',
              }
          })
          console.log(response.data)
          setImageUrl(response.data)
      } catch (error) {
          console.error('Error al subir imagen:', error.message)
      }
    }
    const handleSubmit = async (event) => {
        event.preventDefault()
        try {  
          await validationSchema.validate(values, { abortEarly: false })
          if (selectedExperts.length === 0) {
            setErrors(prevErrors => ({
                ...prevErrors,
                vocations: "Debe seleccionar al menos una especialidad."
            }))
            return
            }
          setIsSubmitting(true)
          const vocationsIds = selectedExperts.map(expert => expert.id)      
          console.log(values) 
          const requestBody = {            
            cuit: values.cuit, 
            link: values.web,
            businessName: values.socialName,
            profileImage: imageUrl,
            vocationsId: vocationsIds          
          }
          const token = localStorage.getItem('token')

          const response = await axios.put('https://www.eventplanner.somee.com/api/Contractor/Update', requestBody,{
              headers: {
                  'Authorization': `Bearer ${token}`,
              }
          })
          console.log(requestBody)
          console.log('Respuesta API: ', response.data)
          localStorage.setItem('contractorProfileImage', response.data.profileImage)
          localStorage.setItem('vocations', JSON.stringify(selectedExperts))

          const roleResponse = await axios.post('https://www.eventplanner.somee.com/api/Acounts/ChangeRole',null,{
            headers: {
                'Authorization': `Bearer ${token}`,
            }
          })
          if (roleResponse.data) {
            localStorage.setItem('token', roleResponse.data.token)
            console.log('Token actualizado:', roleResponse.data.token)
            localStorage.setItem('role', roleResponse.data.user.role)
            console.log('Role actualizado:', roleResponse.data.user.role)
          }
          navigate('/userdashboard')

        } catch (error) {
            console.error('Error al enviar el formulario:', error)
            setErrors({
                general: 'Hubo un error al enviar el formulario. Por favor, inténtelo de nuevo más tarde.'
            })
        }        
        setIsSubmitting(false)
    }   

  return (
    <Container minW='100%' p='4' bg='rgba(180, 224, 223, .2)'>      
      <Box display='flex' justifyContent='center' p='2' >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width={{base:'100%', sm: '70%', md:'45%'}} boxShadow='xl'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg' fontFamily='heading'>REGISTRO DE EMPRESAS</Heading>
            </Center>
            <Link to='/userdashboard'><CloseButton position='absolute' right={{base:'0.5rem',sm:'1rem'}} top='50%' transform='translateY(-50%)' size={{base:'sm',sm:'lg'}} p='1'/></Link>
          </CardHeader>
          <CardBody width='90%' fontFamily='body'>
            <form onSubmit={handleSubmit}>                
                <HStack spacing='10' flexDirection='column'>
                    <Image src={imageUrl ? imageUrl : avatar} alt='Imagen de perfil' boxSize='44' borderRadius='xl' m='-6' />
                    <Input placeholder='Seleccionar Archivo' size='sm' w='60%' type='file' accept=".jpg, .jpeg, .png, .webp"  border='none'/>
                    <Button variant='outline' borderRadius='3xl' fontSize='xs' boxSize='fit-content' color='#CC949F' py='1' mt='-6' onClick={handleImgSubmit}>Cargar Foto</Button>
                    <Box w='80%' display='flex' flexDirection='column' gap='4' mt='-8'>
                        <LoginInput id='socialName' name='Razón Social' type='text' placeholder='Juan Rodriguez' onChange={handleChange} errors={errors}/>

                        <LoginInput id='web' name='Página Web' type='text' placeholder='www.miseventos.com' onChange={handleChange} errors={errors}/>

                        <LoginInput id='cuit' name='Número de CUIT' type='number' placeholder='20-28694513-4' onChange={handleChange} errors={errors}/>
                                              
                        <Box position="relative" zIndex="1" width='100%'>
                            <FormLabel>Especialidades:</FormLabel>
                            <Box onClick={handleExpertModalOpen} 
                            cursor='pointer' 
                            borderWidth='1px' 
                            display='flex'
                            alignItems='center'
                            flexWrap='wrap'
                            p='2'
                            borderRadius='md'                            
                            borderColor='black'
                            maxH='20vh'
                            overflowY='auto'
                            >
                                {selectedExperts.length > 0
                                ?
                                selectedExperts.map((expert, index) => (
                                    <Tag key={index} m='1'>
                                        <TagLabel>{expert.name}</TagLabel>
                                        <TagCloseButton onClick={(e) => { e.stopPropagation(); handleTagRemove(index) }}/>
                                    </Tag>
                                ))
                                :
                                <Text color='gray' pl='2'>Agregar Especialidad</Text>
                                }
                            </Box>
                            <EventModal
                                isOpen={isExpertModalOpen}
                                onClose={handleExpertModalClose}
                                title="Seleccionar Especialidad">
                                <List cursor='pointer'>
                                {expertOptions.map((expertOption, index) => (
                                    <ListItem key={index} onClick={() => handleExpertOptionClick(expertOption)}>
                                        <Button 
                                        variant='ghost' 
                                        width='100%'
                                        isDisabled={selectedExperts.some(expert => expert.id === expertOption.id)}                                       
                                        >
                                            {expertOption.name}
                                        </Button>
                                    </ListItem>
                                ))}
                                </List>
                            </EventModal>                             
                        </Box> 
                    </Box>                
                    <Box textAlign='center' mt='4' w='100%'>
                        <Flex alignItems='center' justifyContent='center'>
                        <IoCheckmarkCircleOutline size='20'/> 
                        <Text fontSize='xs' p='2' display='flex' flexDirection={{base:'column', md:'row'}} gap='1'>Acepto</Text>
                        <Text fontSize='xs' fontWeight='700' color='#263049' cursor='text'>términos y condiciones.</Text> 
                        </Flex>                        
                        <LoginButton bgcolor='#263049' color='white' name='Confirmar' isLoading={isSubmitting}/>                        
                    </Box>
                </HStack>
            </form>
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center' mt='-8'>            
            <CancelAlert navlink={'/userdashboard'}/>
          </CardFooter>          
        </Card>
      </Box>
  </Container>
  )
}

export default ContractorForm