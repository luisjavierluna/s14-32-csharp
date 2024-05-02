import { Box, Button, Card, CardBody, CardHeader, Center, FormErrorMessage, FormLabel, Heading,  Input,  Modal, ModalBody, ModalCloseButton, ModalContent, ModalHeader, ModalOverlay, Tab, TabList, TabPanel, TabPanels, Tabs, Text, Textarea } from "@chakra-ui/react"
import * as Yup from 'yup'
import { useEffect, useState } from "react"
import LoginButton from "../Login/LoginButton"
import axios from "axios" 
import { useNavigate } from "react-router-dom"

const PostulationForm = ({ isOpen, onClose, eventVocations, eventId, eventData }) => {
    const [errors, setErrors] = useState({})
    const [values, setValues] = useState({ budget: 0, website: '', message: '' })
    const [isSubmitting, setIsSubmitting] = useState(false)
    const [vocations, setVocations] = useState([])
    const [matchingVocations, setMatchingVocations] = useState([])
    const [selectedVocation, setSelectedVocation] = useState(matchingVocations[0] || null)
    const [vocationError, setVocationError] = useState(false)
    const navigate = useNavigate()

    useEffect(() => { 
        if (eventData) {
        console.log(eventData)       
        const storedVocations = JSON.parse(localStorage.getItem('vocations'));
        if (storedVocations) {
            setVocations(storedVocations)
        }}
    }, [eventData])
    useEffect(() => { 
        if (vocations){     
        const matchedVocations = vocations?.filter(vocation => eventVocations.some(eventVocation => eventVocation.id === vocation.id))
        setMatchingVocations(matchedVocations)}
    }, [vocations, eventVocations])

    const validationSchema = Yup.object().shape({
        message: Yup.string().required('Ingrese un mensaje'),
        website: Yup.string().required('Ingrese website'),
        budget: Yup.number().min(2, 'Mínimo 2 caractares').required('Ingrese monto presupuestado')       
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
          if (!selectedVocation) {
            setVocationError(true)
            return
            }
          setIsSubmitting(true) 
          const contractorId = localStorage.getItem('userId')
          const requestBody = {
            contractorId: contractorId,
            vocationId: selectedVocation.id,
            eventId: eventId,
            message: values.message,
            budget: values.budget
          }          
          const token = localStorage.getItem('token')         
          const response = await axios.post('https://www.eventplanner.somee.com/api/Postulation/Insert', requestBody,{
            headers: {
                Authorization: `Bearer ${token}`
            }
            })
          console.log(response.data)                     
          onClose()
          navigate('/userdashboard')     
        } catch (error) {
          const formErrors = {}
          if (error.inner) {
          error.inner.forEach(err => {
            formErrors[err.path] = err.message;
          })
          setErrors(formErrors)
        } else {
          console.error('Error desconocido:', error.message);
        }
        }
        setIsSubmitting(false)
      } 

  return (
    <Modal isOpen={isOpen} onClose={onClose} isCentered size='xl'>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>
        {matchingVocations.length >0 ? matchingVocations.map((vocation, index) => (
            <Button
                key={index}
                variant={selectedVocation && selectedVocation.id === vocation.id ? "outline" : "ghost"}                
                opacity={selectedVocation && selectedVocation.id === vocation.id ? '1' : '.3'}
                onClick={() => {setSelectedVocation(vocation), setVocationError(false)}}
            >
                {vocation.name}
            </Button>
        )) : <Text>Especialidades</Text>}
        </ModalHeader>
        <ModalCloseButton />
        <ModalBody p='4'>
            <Card mt='-6' boxShadow='none'>
                <CardHeader mt='-4'>
                    <Center>
                        <Heading size='lg' fontFamily='heading'>Postulación</Heading>
                    </Center>
                </CardHeader>
                <CardBody mt='-6' fontFamily='body'>
                    {eventData &&
                    <Box color='#263049'>
                    <Tabs >
                        <TabList>
                            <Tab>Nombre y Tipo Evento</Tab>                           
                            <Tab>Descripción</Tab>
                            <Tab>Info Evento</Tab>                                                       
                        </TabList>
                        <TabPanels>
                            <TabPanel>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Nombre del Cliente:</Text><Text>{eventData?.clientName || ''}</Text></Box>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Nombre del Evento:</Text><Text> {eventData?.name || ''}</Text></Box>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Tipo de Evento:</Text><Text>{eventData?.eventType?.name || ''}</Text></Box>
                            </TabPanel> 
                            <TabPanel>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Descripción:</Text><Text>{eventData?.description || ''}</Text></Box>
                            </TabPanel>
                            <TabPanel>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Fecha y Hora:</Text><Text>{eventData?.initDate || ''}</Text></Box>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Duración:</Text><Text>{eventData?.duration || ''}</Text></Box>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Cantidad de Invitados:</Text><Text>{eventData?.guests || ''}</Text></Box>
                                <Box display='flex' gap='2'><Text fontWeight='semibold'>Ciudad:</Text><Text>{eventData?.city || ''}</Text></Box>
                            </TabPanel>                            
                        </TabPanels>
                    </Tabs>                        
                    </Box>}
                    <form onSubmit={handleSubmit}>    
                    <Box display='flex' flexDirection='column' alignItems='center' gap='6' >
                        <Box w='full'>
                            <FormLabel>Presupuesto estimado:</FormLabel>
                            <Input id='budget' name='budget' type='text' placeholder='$$' value={values.budget} onChange={handleChange} />
                            {errors.budget && <FormErrorMessage>{errors.budget}</FormErrorMessage>}
                        </Box>
                        <Box w='full'>
                            <FormLabel>Sitio web:</FormLabel>
                            <Input id='website' name='website' type='text' placeholder='Ingrese su sitio web' value={values.website} onChange={handleChange} />
                            {errors.website && <FormErrorMessage>{errors.website}</FormErrorMessage>}
                        </Box>
                        <Box w='full'>
                            <FormLabel>Mensaje:</FormLabel>
                            <Textarea id='message' name='message' placeholder='Ingrese un mensaje' value={values.message} onChange={handleChange} bg='rgba(204, 148, 159, .12)'/>
                            {errors.message && <FormErrorMessage>{errors.message}</FormErrorMessage>}
                        </Box>
                        {vocationError && <Text color="red">Debe seleccionar una vocación</Text>}                                         
                        <Box w='40%'>
                            <LoginButton bgcolor='#263049' color='white' name='Confirmar' isLoading={isSubmitting}/>                            
                        </Box>
                    </Box>
                    </form>                     
                </CardBody>
            </Card>                  
        </ModalBody>
      </ModalContent>
    </Modal>
   
  )
}

export default PostulationForm
