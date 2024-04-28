import { Box, Card,  Center, Heading,  CardBody, Text, CardHeader, Button, CloseButton } from '@chakra-ui/react'
import React, { useEffect, useState } from 'react'
import {  HiOutlineCamera, HiOutlineCake, GiMusicalNotes, PiMicrophoneStage, FaPeopleGroup,  HiOutlineTruck, MdEventNote, FaPencilAlt, GiFairyWand, FaMicrophone, GrUserPolice, MdOutlineDirectionsBus, FaBed, FaHandshake, FaUserEdit, FaRegSmile, MdOutlineCleanHands, HiOutlineVideoCamera, TfiMicrophoneAlt, HiOutlineClipboardList, HiOutlineGlobe, HiOutlineUserGroup, HiOutlineCalendar, TbClockHour8, QuestionOutlineIcon } from '../../assets/icons'


const PostulationEventCard = ({ postulation, events, eventId, isOpen, onClose }) => {
    const [postulationData, setPostulationData] = useState()
    const [eventData, setEventData] = useState() 
    const [vocations, setVocations] = useState()     
    
    
    useEffect(() => {
        const filteredPostulation = postulation.find(post => post.eventId === eventId)
        const filteredEvent = events.find(event => event.id === filteredPostulation.eventId) 
        setEventData(filteredEvent)
        setPostulationData(filteredPostulation)
        setVocations(JSON.parse(localStorage.getItem('vocations')))
        
    }, [events, postulation, eventId])
     
    const formatDateTime = (dateTimeString) => {
        if (!dateTimeString) return ''
        const [datePart] = dateTimeString.split('T')        
    
        const [year, month, day] = datePart.split('-')
        const formattedDate = `${day}-${month}-${year}` 
    
        return `${formattedDate}`
    }
           
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
    const nombreVocation = vocations?.find(vocation => vocation.id === postulationData?.vocationId)?.name
    
    return (
        <Box display={isOpen ? 'block' : 'none'} position="fixed" zIndex="9999" top="0" bottom="0" left="0" right="0" bg="rgba(0, 0, 0, 0.5)" onClick={onClose}>
            <Box position="absolute" top="50%" left="50%" transform="translate(-50%, -50%)" width="90%" maxWidth="600px" bg="white" p='12' borderRadius="3xl" boxShadow="lg" onClick={(e) => e.stopPropagation()}>               
            <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' boxShadow='xl' minH='50vh' bg='rgba(204, 148, 159, .2)'>
                <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
                    <Center width='100%'>
                        <Heading size='lg' fontFamily='heading'>{eventData?.name || 'Nombre del Evento'}</Heading>
                    </Center>
                    <CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg' onClick={onClose}/>                
                </CardHeader>
                <CardBody width='100%' mt='-4' fontFamily='body' px='6'>                
                        <Box display='flex' flexDirection='column'  alignItems='center' gap='2' w='full' >
                            <Box display='flex' justify="space-between" w="100%" gap='8' overflowX='scroll'>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2' ml={{base:'5', md:'1'}}>
                                    <HiOutlineCalendar size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" 
                                    w={{base:'20', md:'22'}}>
                                        {formatDateTime(eventData?.initDate) || 'Fecha'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <TbClockHour8 size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm" color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {eventData?.duration || 'Duración'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <HiOutlineUserGroup size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {eventData?.guests || 'Invitados'}
                                    </Text>
                                </Button>
                                <Button variant="ghost" colorScheme="white" display="flex" flexDirection="column" alignItems="center" maxW="25%" minH='20' mx='2'>
                                    <HiOutlineGlobe size='30' />
                                    <Text bg='white' border="1px" borderRadius="md" fontSize="sm"  color="gray.500" fontWeight="500" mt={2} textAlign="center" w={{base:'20',md:'22'}}>
                                        {eventData?.city || 'Ciudad'}
                                    </Text>
                                </Button>
                            </Box>
                            <Box width='100%' mt='4' display='flex' flexDirection='column' alignItems='center' gap='1'>                            
                                    <Text minWidth={{md:'160'}} fontWeight='semibold'>Descripción del Evento</Text>
                                    <Text size='sm' borderWidth='2px' w='100%' maxH='15vh' overflowY='scroll' bg='white' borderRadius='lg' p='1'>{eventData?.description || 'Descripción del Evento...'}</Text>
                            </Box>
                            <Box>
                                <Box display='flex' justifyContent='center' alignItems='center' gap='2' py='2'>
                                    {expertIcons[nombreVocation] ? React.createElement(expertIcons[nombreVocation], { size: 30 }) : <QuestionOutlineIcon/>}
                                    <Text bg='white' borderRadius='lg' w='90%' py='1' px='3' overflow='hidden' h='8' >{nombreVocation}</Text>
                                </Box>
                                <Text bg='white' borderRadius='lg' p='1' h='15vh' overflowY='auto'>{postulationData?.message}</Text>
                            </Box>                        
                        </Box>               
                </CardBody>                               
            </Card> 
            </Box>            
        </Box>
    )
}

export default PostulationEventCard