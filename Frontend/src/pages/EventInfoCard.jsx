import { Container, Box, Card, CardHeader, Center, Heading, CloseButton, CardBody, CardFooter, FormControl, FormLabel, Input, IconButton, List, ListItem, Button, Text, Divider, Link, useDisclosure } from '@chakra-ui/react'
import React, { useEffect, useState } from 'react'
import { LoginButton, EventModal, PostulationListModal } from '../components'
import { HiOutlineTag, HiOutlineCamera, HiOutlinePlusCircle, HiOutlineCake, GiMusicalNotes, PiMicrophoneStage, FaPeopleGroup, QuestionOutlineIcon, HiOutlineTruck, MdEventNote, FaPencilAlt, GiFairyWand, FaMicrophone, GrUserPolice, MdOutlineDirectionsBus, FaBed, FaHandshake, FaUserEdit, FaRegSmile, MdOutlineCleanHands, HiOutlineVideoCamera, TfiMicrophoneAlt, HiOutlineClipboardList, HiOutlineCalendar, TbClockHour8, HiOutlineUserGroup, HiOutlineGlobe } from '../assets/icons'
import axios from 'axios'
import { useNavigate, useParams } from 'react-router-dom'

const EventInfoCard = () => {    
    const { id } = useParams()
    const [eventData, setEventData] = useState(null)
    const [isEventModalOpen, setIsEventModalOpen] = useState(false)
    const [selectedEventOption, setSelectedEventOption] = useState(null)
    const [isExpertModalOpen, setIsExpertModalOpen] = useState(false)
    const [selectedExpertOption, setSelectedExpertOption] = useState(null)
    const [selectedExperts, setSelectedExperts] = useState([])  
    const [error, setError] = useState(false)
    const [isSubmitting, setIsSubmitting] = useState(false)
    const navigate = useNavigate()
    const [location, setLocation] = useState({ cityId: '', address: '', city: ''})
    const [date, setDate] = useState('')
    const [duration, setDuration] = useState('')
    const [guests, setGuests] = useState('')
    const [eventName, setEventName] = useState('')
    const [eventDescription, setEventDescription] = useState('')
    const [expertOptions, setExpertOptions] = useState([])    
    const [selectedExpertIds, setSelectedExpertIds] = useState([])
    const [eventOptions, setEventOptions] = useState([]) 
    const { isOpen, onOpen, onClose } = useDisclosure()
    const [selectedPostulations, setSelectedPostulations] = useState([])
    const [postulations, setPostulations] = useState(null)
     
    //EventsModal    
    const handleEventModalOpen = () => {setIsEventModalOpen(true)}  
    const handleEventModalClose = () => {setIsEventModalOpen(false)}
    const handleEventOptionClick = (eventOption) => {
        setSelectedEventOption(eventOption)
        handleEventModalClose()
    }
    //ExpertsModal     
    const expertIcons = { 
        "Organizador de eventos": MdEventNote,
        "Coordinador de logística": HiOutlineTruck,
        "Coordinador de catering": HiOutlineCake,
        "Diseñador gráfico": FaPencilAlt,
        "Diseñador de escenarios y decoración": GiFairyWand,
        "Técnico de sonido y luces": GiMusicalNotes,
        "Coordinador de entretenimiento": PiMicrophoneStage,
        "Coordinador de medios y relaciones públicas": FaMicrophone,
        "Coordinador de seguridad": GrUserPolice,
        "Coordinador de transporte": MdOutlineDirectionsBus,
        "Coordinador de hospedaje": FaBed,
        "Coordinador de protocolo y relaciones institucionales": FaHandshake,
        "Fotógrafo": HiOutlineCamera,
        "Videógrafo": HiOutlineVideoCamera,
        "Maestro de ceremonias": TfiMicrophoneAlt,
        "Asistente de producción": HiOutlineClipboardList,
        "Diseñador de experiencia de usuario (UX)": FaUserEdit,
        "Diseñador de experiencia de cliente (CX)": FaRegSmile,
        "Coordinador de voluntarios": FaPeopleGroup,
        "Coordinador de limpieza y mantenimiento": MdOutlineCleanHands
    }
    const handleExpertModalOpen = () => {setIsExpertModalOpen(true)}  
    const handleExpertModalClose = () => {setIsExpertModalOpen(false)}
    const handleExpertOptionClick = (expertOption) => {
        setSelectedExpertOption(expertOption)
        handleExpertModalClose()
    }
    const handleAddExpertToList = () => {    
        if (selectedExpertOption !== null && !selectedExperts.includes(selectedExpertOption.name)) {
        setSelectedExperts([...selectedExperts, selectedExpertOption.name])
        setSelectedExpertIds([...selectedExpertIds, selectedExpertOption.id])
        setSelectedExpertOption(null)
        setError(false)
        }else {
        setError(true)
        }
    } 
    const handleRemoveExpertFromList = (expertToRemove) => {
        setSelectedExperts(selectedExperts.filter(expert => expert !== expertToRemove));
    }  
    const handleEventSubmit = async (event) => {
        event.preventDefault()
        try {            
        const eventData = {
            name: eventName,
            description: eventDescription,
            eventTypeId: selectedEventOption.id,
            initDate: date,
            duration: duration,
            guests: guests,            
            cityId: location.cityId,
            address: location.address,
            vocationsId: selectedExpertIds
        }      
        setIsSubmitting(true) 
        const token = localStorage.getItem('token')      
        const response = await axios.put(`https://www.eventplanner.somee.com/api/Events/${id}`, eventData,{
            headers: {
                Authorization: `Bearer ${token}`
            }
        })
        console.log(response.data) 
        navigate('/userdashboard') 
        } catch (error) {
        console.error('Error al enviar los cambios:', error.message)
        }
        setIsSubmitting(false)
    }      

    useEffect(() => {
        const fetchData = async () => {
          try {
            const token = localStorage.getItem('token')        
            const responseEvents = await axios.get('https://www.eventplanner.somee.com/api/Events/myEvents',{
              headers: {
                  Authorization: `Bearer ${token}`
              }
            })
            const filteredEvent = responseEvents.data.find(item => item.id === id)
            console.log(filteredEvent)
            setEventData(filteredEvent)            
            setLocation({ cityId: filteredEvent.cityId, address: filteredEvent.address, city: filteredEvent.city })
            setDate(filteredEvent.initDate)
            setDuration(filteredEvent.duration)
            setGuests(filteredEvent.guests)
            setEventName(filteredEvent.name)
            setEventDescription(filteredEvent.description)
            setSelectedExpertIds(filteredEvent.vocations.map(vocation => vocation.id))
            setSelectedExperts(filteredEvent.vocations.map (vocation => vocation.name))
            setSelectedEventOption(filteredEvent.eventType)
            setPostulations(filteredEvent.postulations)
            
            const responseVocations = await axios.get('https://www.eventplanner.somee.com/api/Vocation/GetAll')
            console.log(responseVocations.data)
            setExpertOptions(responseVocations.data)

            const responseEventType = await axios.get('https://www.eventplanner.somee.com/api/EventType')
            console.log(responseEventType.data)
            setEventOptions(responseEventType.data)
            
          } catch (error) {
            console.error('Error al obtener informacion del evento:', error.message)
          }
        }
        fetchData()
    }, [id]) 

    const filterPostulationsByVocation = (vocationId) => {
            return postulations.filter(postulation => postulation.vocationId === vocationId);
    }   
    
    const handleCardClick = (vocationId) => {            
            const filteredPostulations = filterPostulationsByVocation(vocationId)
            console.log("Postulaciones para la especialidad con ID", vocationId, ":", filteredPostulations);
            setSelectedPostulations(filteredPostulations)
            onOpen() 
    }    

    const handleCloseModal = () => {        
        onClose()
    }

    const formatDateTime = (dateTimeString) => {
        if (!dateTimeString) return ''
        const [datePart] = dateTimeString.split('T')        
    
        const [year, month, day] = datePart.split('-')
        const formattedDate = `${day}-${month}-${year}` 
    
        return `${formattedDate}`
    }

    return (
        <Container minW='100%' minH='100vh' padding='2' bg='rgba(180, 224, 223, .2)'>        
        <Box display='flex' justifyContent='center' padding={{base:'2', md:'7'}} >     
            <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width={{base:'100%', lg:'80%'}} boxShadow='xl'>          
            <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
                <Center width='100%'>
                <Heading size='lg' fontFamily='heading'>{eventName || 'Nuevo Evento'}</Heading>
                </Center>
                <Link href='/userdashboard'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
            </CardHeader>
            <CardBody width='95%' mt='-4' fontFamily='body'>
                <form onSubmit={handleEventSubmit}>
                    <Box display='flex' flexDirection='column' alignItems='center' gap='2'>
                        <Box display='flex' flexDirection={{base:'column', md:'row'}} alignItems='center' gap='4' width='100%'>
                            <FormControl display='flex' flexDirection={{base:'column', md:'row'}} alignItems='center' ml={{ md:'5'}} gap='2'>
                                <FormLabel minWidth={{md:'140'}} fontWeight='semibold'>Nombre del Evento</FormLabel>
                                <Input placeholder='Casamiento de Juan' size='sm' borderRadius='md' value={eventName} onChange={(e) => setEventName(e.target.value)}/>
                            </FormControl>
                            <FormControl display='flex' alignItems='center' gap='1' width={{base:'full', md:'35%'}}>
                                <HiOutlineTag size='30'/> 
                                <Box position="relative" zIndex="1" width='100%'>
                                    <Input
                                        value={selectedEventOption?.name || eventData?.eventType?.name || ''}
                                        readOnly
                                        onClick={handleEventModalOpen}
                                        placeholder="Tipo de evento"
                                        textAlign='center'
                                        size='sm'
                                        borderRadius='md'
                                        cursor='pointer'
                                    />
                                    <EventModal
                                        isOpen={isEventModalOpen}
                                        onClose={handleEventModalClose}
                                        title="Seleccionar tipo de evento">
                                        <List cursor='pointer'>
                                        {eventOptions.map((eventOption, index) => (
                                            <ListItem key={index} onClick={() => handleEventOptionClick(eventOption)}>
                                            <Button variant='ghost' width='100%'>{eventOption.name}</Button>
                                            </ListItem>
                                        ))}
                                        </List>
                                    </EventModal>                   
                                </Box>                    
                            </FormControl>                  
                        </Box>
                        <Box width='100%'>
                            <FormControl display='flex' flexDirection={{base:'column', md:'row'}} alignItems='center' gap='2'>
                                <FormLabel minWidth={{md:'160'}} fontWeight='semibold'>Descripción del Evento</FormLabel>
                                <Input placeholder='Casamiento en un salón de eventos con una pista de baile techada y otra al aire libre....' size='sm' borderRadius='md' value={eventDescription} onChange={(e) => setEventDescription(e.target.value)}/>
                            </FormControl>
                        </Box>
                        <Box width='100%' display='flex' flexDirection={{base:'column', md:'row'}} gap={{base:'4', md:'8'}}>                  
                        <Box display='flex' flexDirection={{base:'row', md:'column'}} gap={{base:'8', md:'0'}} justifyContent='flex-start' alignItems='center' overflowX='scroll' w={{base:'100%', md:'25%'}}>                    
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2' ml={{base:'5', md:'1'}}>
                                    <HiOutlineCalendar size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" 
                                    w={{base:'20', md:'22'}}>
                                        {formatDateTime(date) || 'Fecha'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <TbClockHour8 size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm" color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {duration || 'Duración'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <HiOutlineUserGroup size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {guests || 'Invitados'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <HiOutlineGlobe size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {location.city || 'Ciudad'}
                                    </Text>
                                </Button>
                                     
                        </Box>
                        <Card width='100%' bg='rgba(204, 148, 159, .12)' minH='430' h='50vh'>
                            <CardHeader width='100%'>
                                <Center>
                                    <Heading as='u' size='sm' fontFamily='heading' color='#CC949F'>BÚSQUEDA DE EXPERTOS</Heading>
                                </Center>                    
                            </CardHeader>
                            <CardBody>
                                <FormControl display='flex' alignItems='center' px={{md:'20'}} mt='-6'>
                                <IconButton variant='ghost' colorScheme='teal' aria-label='Call Sage' fontSize='30px' icon={<HiOutlinePlusCircle />} onClick={handleAddExpertToList}/>                    
                                <Box position="relative" zIndex="1" width='100%' >
                                    <Input
                                    value={selectedExpertOption?.name || ""}
                                    readOnly
                                    onClick={handleExpertModalOpen}
                                    placeholder="Agregar búsqueda"
                                    textAlign='center'
                                    size='sm'
                                    borderRadius='md'
                                    bg='white'
                                    cursor='pointer'
                                    borderColor={error ? 'red' : 'gray.200'}
                                    />                        
                                    {(error && selectedExperts.length === 0) && (
                                    <Text color='red'>Debe seleccionar un experto de la lista</Text>
                                    )}
                                    {(error && selectedExperts.length > 0) && (
                                    <Text color='red'>El experto ya está en la lista</Text>
                                    )}
                                    <EventModal isOpen={isExpertModalOpen} onClose={handleExpertModalClose} title="Seleccionar puesto a cubrir">
                                        <List cursor='pointer'>
                                            {expertOptions.map((expertOption, index) => (
                                            <ListItem key={index} onClick={() => handleExpertOptionClick(expertOption)}>
                                                <Button variant='ghost' width='100%'>{expertOption.name}</Button>
                                            </ListItem>
                                            ))}
                                        </List>
                                    </EventModal>                
                                </Box> 
                                </FormControl>
                                <Divider mt='2' borderColor='#CC949F'/>
                                <List mt='8' overflowY='scroll' h='70%'>
                                {selectedExperts.map((expert, index) => (
                                    <ListItem key={index} display='flex' gap='2' alignItems='center' justifyContent='center' pl={{md:'24'}} mt='2'>
                                    {expertIcons[expert] ? React.createElement(expertIcons[expert], { size: 30 }) : <QuestionOutlineIcon/>}
                                        <Text bg='white' borderRadius='md' py='1' px='2' w='100%' display='flex' justifyContent='space-between'>{expert} 
                                            <CloseButton size='sm' onClick={() => handleRemoveExpertFromList(expert)}/>
                                        </Text>
                                        <Button bg='#CC949F' color='white' maxW='75px' fontSize={{base:'xs', md:'sm'}} onClick={() => handleCardClick(selectedExpertIds[index])}>
                                            <Box display="flex" flexDirection="column">
                                            <Text>Ver</Text>
                                            <Text display={{ base: 'none', md: 'block' }}>Propuestas</Text>
                                            </Box>
                                        </Button>                          
                                    </ListItem>
                                ))}
                                
                                </List>
                            </CardBody>
                            {isOpen && (
                                <PostulationListModal
                                    isOpen={isOpen}
                                    onClose={handleCloseModal}
                                    postulations={selectedPostulations}                                    
                                />
                            )}
                        </Card>                  
                        </Box>
                        <Box width={{base:'70%', md:'50%'}} mt='4'>                
                            <LoginButton bgcolor='#263049' color='white' name='GUARDAR EVENTO' isLoading={isSubmitting}/> 
                        </Box>
                    </Box>
                </form>
            </CardBody>            
            </Card>
        </Box>
        </Container>
    )
}

export default EventInfoCard