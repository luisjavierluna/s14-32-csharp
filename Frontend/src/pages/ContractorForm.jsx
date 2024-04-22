import { Box, Button, Card, CardBody, CardFooter, CardHeader, Center, CloseButton, Container, Flex, FormControl, HStack, Heading, Image, Input, List, ListItem, Text } from "@chakra-ui/react"
import { Link } from "react-router-dom"
import { CancelAlert, LoginButton, LoginInput } from "../components"
import { IoCheckmarkCircleOutline } from '../assets/icons'
import * as Yup from 'yup'
import { useState } from "react"
import avatar from '../assets/avatar.png'

const ContractorForm = () => {
    const [isSubmitting, setIsSubmitting] = useState(false)
    const [errors, setErrors] = useState({})
    const [values, setValues] = useState({ socialName:'', web:'', cuit: 0 })
    const [selectedExperts, setSelectedExperts] = useState([])
    const [isExpertModalOpen, setIsExpertModalOpen] = useState(false)

    const handleExpertOptionClick = (expertOption) => {
        if (!selectedExperts.some(expert => expert.id === expertOption.id)) {
        setSelectedExperts([...selectedExperts, expertOption])
        }
        handleExpertModalClose()
    }

    const handleExpertModalOpen = () => {
        setIsExpertModalOpen(true)
    }

    const handleExpertModalClose = () => {
        setIsExpertModalOpen(false)
    }

    const validationSchema = Yup.object().shape({        
        socialName: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),
        web: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),        
        cuit: Yup.number().min(5, 'Mínimo 5 caractares').required('Campo requerido'),
    })

    const handleChange = (event) => {
        const { name, value } = event.target
        setValues({
        ...values,
        [name]: value
        })
    }
    const handleSubmit = async (event) => {
        event.preventDefault()
        try {  
          await validationSchema.validate(values, { abortEarly: false })
          setIsSubmitting(true)      
          console.log(values) 
          const requestBody = {
            socialName: values.socialName,
            web: values.web,
            cuit: values.cuit
          }
          /* await axios.post('https://www.eventplanner.somee.com/api/Acounts/SignIn', requestBody)  */  
          console.log(requestBody)
          /* navigate('/login') */
        } catch (error) {
          const formErrors = {}
          if (error.inner) {
            error.inner.forEach((err) => {
              formErrors[err.path] = err.message;
            })
          } else {
            formErrors.general = error.message
          setErrors(formErrors)
          }
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
            <Link href='/'><CloseButton position='absolute' right={{base:'0.5rem',sm:'1rem'}} top='50%' transform='translateY(-50%)' size={{base:'sm',sm:'lg'}} p='1'/></Link>
          </CardHeader>
          <CardBody width='90%' fontFamily='body'>
            <form onSubmit={handleSubmit}>                
                <HStack spacing='10' flexDirection='column'>
                    <Image src={avatar} alt='Imagen de perfil' boxSize='44' borderRadius='xl' m='-6' />
                    <Button variant='outline' borderRadius='3xl' fontSize='xs' boxSize='fit-content' color='#CC949F' py='1'>Cargar Foto</Button>
                    <Box w='80%' display='flex' flexDirection='column' gap='4' mt='-8'>
                        <LoginInput id='socialName' name='Razón Social' type='text' placeholder='Juan Rodriguez' onChange={handleChange} errors={errors}/>                              
                        <LoginInput id='web' name='Página Web' type='text' placeholder='juanrodriguez@gmail.com' onChange={handleChange} errors={errors}/>
                        <LoginInput id='cuit' name='Número de CUIT' type='number' placeholder='20-28694513-4' onChange={handleChange} errors={errors}/>
                        <FormControl display='flex' alignItems='center' gap='1' width={{base:'full', md:'35%'}}>                        
                        <Box position="relative" zIndex="1" width='100%'>
                            <Input
                            value={selectedExperts.map(expert => expert.name).join(', ') || ""}
                            readOnly
                            onClick={handleExpertModalOpen}
                            placeholder="Tipo de evento"
                            textAlign='center'
                            size='sm'
                            borderRadius='md'
                            cursor='pointer'
                            />
                            {isExpertModalOpen && (
                            <List cursor='pointer'>
                                {expertOptions.map((expertOption, index) => (
                                <ListItem key={index} onClick={() => handleExpertOptionClick(expertOption)}>
                                    <Button variant='ghost' width='100%'>{expertOption.name}</Button>
                                </ListItem>
                                ))}
                            </List>
                            )}
                        </Box>                    
                        </FormControl> 
                    </Box>                
                    <Box textAlign='center' mt='4' w='100%'>
                        <Flex alignItems='center' justifyContent='center'>
                        <IoCheckmarkCircleOutline size='20'/> 
                        <Text fontSize='xs' p='2' display='flex' flexDirection={{base:'column', md:'row'}} gap='1'>                                         
                            Acepto
                            <Text fontSize='xs' fontWeight='700' color='#263049' cursor='text'>términos y condiciones.</Text>        
                        </Text>
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