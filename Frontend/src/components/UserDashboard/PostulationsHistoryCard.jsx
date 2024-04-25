import { Box, Button, Card, CardBody, CardFooter, CardHeader, Center, Flex, Heading, Image, useDisclosure } from "@chakra-ui/react"
import axios from "axios"
import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import EventForm from '../../assets/postulable.png'
import { HiOutlinePlusCircle } from '../../assets/icons'
import { PostulationEventCard } from '../index'


const PostulationsHistoryCard = () => {
    const [postulationsCreated, setPostulationsCreated] = useState([])    
    const [events, setEvents] = useState([])
    const [selectedEventId, setSelectedEventId] = useState(null) 
    const { isOpen, onOpen, onClose } = useDisclosure()   

    useEffect(() => {
        const fetchEvents = async () => {
            try {
                const token = localStorage.getItem('token');
                const response = await axios.get('https://www.eventplanner.somee.com/api/Events/postulable', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                })
                setEvents(response.data)

                console.log('EVENTOS: ', response.data)
            } catch (error) {
                console.error('Error al obtener lista de eventos:', error.message)
            }
        };

        fetchEvents();
    }, [])

  const handleCardClick = (eventId) => {
        setSelectedEventId(eventId)
        onOpen()
    }

    const handleCloseModal = () => {
        setSelectedEventId(null)
        onClose()
    }

  useEffect(() => {
    const fetchPostulationsCreated = async () => {
      try {
        const token = localStorage.getItem('token')        
        const response = await axios.get('https://www.eventplanner.somee.com/api/Postulation/GetMyPostulations',{
          headers: {
              Authorization: `Bearer ${token}`
          }
        })        
        setPostulationsCreated(response.data)
        console.log(response.data)
      } catch (error) {
        console.error('Error al obtener historial de postulaciones:', error.message)
      }
    }
    fetchPostulationsCreated()
  }, [])   
 
  return (
    <Card bg='rgba(180, 224, 223, .2)' color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='full' boxShadow='xl' h='70vh'>          
        <CardHeader >
          <Center width='100%'>
              <Heading size='md' fontFamily='heading' color='rgba(38, 48, 73, .7)'>MIS POSTULACIONES</Heading>
            </Center>
        </CardHeader>
        <CardBody  
          width='100%'
          mt='-4'
          fontFamily='body'
          overflowY='auto'
          maxHeight='65vh'
          display='grid'
          gridTemplateColumns={postulationsCreated.length > 0?{ base: 'repeat(1, 1fr)', md: 'repeat(2, 1fr)', lg:'repeat(3, 1fr)' } : 'repeat(1, 1fr)'}
          gap='6'
          p='3'
          justifyItems='center'>
          {postulationsCreated.map(event => { 
              const correspondingEvent = events.find(e => e.id === event.eventId);

              return (
                  <Box key={event.id}>          
                      <Box key={event.id} onClick={() => handleCardClick(event.eventId)} flexDirection='column' w={{base:'50vw', md:'35vw', lg:'20vw'}} textAlign='center'>                          
                          <Heading py='2' size='sm'>{correspondingEvent ? correspondingEvent.name : 'Evento'}</Heading>
                          <Image src={EventForm} alt={event.name} borderRadius='md'/>              
                      </Box>            
                  </Box>             
              );
          })}         
          <Center flexDirection='column' w='52' h='52' mt='-2'>
              <Button as={Link} to='/postulableevents' color='#263049' variant='ghost' py='2' borderRadius='md'>
                <Flex align='center' flexDirection='column' gap='2'>
                  <Heading size='sm' ml='2'>Nueva Postulación</Heading>
                  <HiOutlinePlusCircle size={20} />                  
                </Flex>
              </Button>
            </Center>
          
        </CardBody>        
            {isOpen && (
                <PostulationEventCard
                    isOpen={isOpen}
                    onClose={handleCloseModal}
                    postulation={postulationsCreated}
                    events={events}
                    eventId={selectedEventId}
                />
            )}
        <CardFooter > 

        </CardFooter>
    </Card>
  )
}

export default PostulationsHistoryCard