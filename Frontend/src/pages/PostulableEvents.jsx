import { Box, Button, Card, CardBody, CardHeader, Heading, Image, Input, List, ListItem, Text } from "@chakra-ui/react"
import axios from "axios"
import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import Postulable from '../assets/postulable.png'
import { DrawerMenu, EventModal, PostulationForm } from "../components"
import { HiOutlineFilter } from '../assets/icons'

const userRole = localStorage.getItem('role') 

const PostulableEvents = () => {
  const [postulableEventsList, setPostulableEventsList] = useState([])
  const [eventOptions, setEventOptions] = useState([])
  const [isEventModalOpen, setIsEventModalOpen] = useState(false)
  const [selectedEventOption, setSelectedEventOption] = useState(null)
  const [loadAllEvents, setLoadAllEvents] = useState(true)
  const [openEventFormId, setOpenEventFormId] = useState(null)
 

  const handlePostulationFormOpen = (eventId) => { setOpenEventFormId(eventId) }  
  const handlePostulationFormClose = () => { setOpenEventFormId(null) }

  const handleEventModalOpen = () => {setIsEventModalOpen(true)}  
  const handleEventModalClose = () => {setIsEventModalOpen(false)}
  const handleEventOptionClick = (eventOption) => {
    console.log("Event Option:", eventOption)
    if (eventOption && eventOption.name === "Todos") {
        setSelectedEventOption(null)
        setLoadAllEvents(true)
    } else {
        setSelectedEventOption(eventOption)
        setLoadAllEvents(false)
    }
    handleEventModalClose()
  }

  useEffect(() => {
    const fetchEventsTypes = async () => {
      try {                
        const responseEventTypes = await axios.get('https://www.eventplanner.somee.com/api/EventType')
        console.log(responseEventTypes.data)
        const updatedEventOptions = [...responseEventTypes.data, { id: 8, name: 'Todos' }]
        setEventOptions(updatedEventOptions)        
      } catch (error) {
        console.error('Error al obtener lista de tipos de eventos:', error.message)
      }
    }
    fetchEventsTypes()
  }, [])

  useEffect(() => {    
      const fetchEvents = async () => {       
       const token = localStorage.getItem('token')        
        let url = 'https://www.eventplanner.somee.com/api/Events/postulable'
        if (!loadAllEvents && selectedEventOption !== null) {
          url += `?type=${selectedEventOption.id}`
        }
        try {
                 
          const response = await axios.get(url, {
            headers: {
              Authorization: `Bearer ${token}`
            }
          });        
          setPostulableEventsList(response.data)
          console.log('fetchFilteredEvents')
        } catch (error) {
          console.error('Error al obtener lista de eventos postulables:', error.message)
        }
      }
      fetchEvents()    
  }, [loadAllEvents, selectedEventOption]) 
  
  return (
    <Card bg='rgba(180, 224, 223, .2)' color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='full' boxShadow='xl' minH='80vh'>          
        <CardHeader width='full'>
        <Box display='flex' justifyContent='space-between' w='full' pb='2'>
                <DrawerMenu placement='left' title='Menú'>
                    <List display='flex' flexDirection='column' gap='2' >
                        {userRole === 'client' &&
                        <ListItem><Link to='/contractorform'><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }}>Quiero ser Proveedor</Button></Link></ListItem>}
                        <ListItem><Link to='/userdashboard'><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} >Mis Eventos</Button></Link></ListItem>
                        {userRole === 'contractor' &&
                        <ListItem><Link to='/userdashboard'><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} >Mis Postulaciones</Button></Link></ListItem>}
                    </List>
                </DrawerMenu>               
                <Box display='flex' alignItems='center' gap='2'>
                    <HiOutlineFilter size={20}/>
                    <Box position="relative" zIndex="1" width='100%'>
                      <Input
                        value={selectedEventOption?.name || ""}
                        readOnly
                        onClick={handleEventModalOpen}
                        placeholder="Filtros"
                        textAlign='center'
                        size='sm'
                        borderRadius='md'
                        cursor='pointer'
                      />
                      <EventModal
                        isOpen={isEventModalOpen}
                        onClose={handleEventModalClose}
                        title="Seleccionar un tipo de evento">
                        <List cursor='pointer'>
                          {eventOptions.map((eventOption, index) => (
                            <ListItem key={index} onClick={() => handleEventOptionClick(eventOption)}>
                              <Button variant='ghost' width='100%'>{eventOption.name}</Button>
                            </ListItem>
                          ))}
                        </List>
                      </EventModal>                   
                    </Box>    
                </Box>
            </Box>
        </CardHeader>
        <CardBody  
          width='100%'
          mt='-4'
          fontFamily='body'
          overflowY='auto'
          maxHeight='65vh'
          display='grid'
          gridTemplateColumns={postulableEventsList.length > 0?{ base: 'repeat(1, 1fr)', md: 'repeat(2, 1fr)', lg:'repeat(3, 1fr)' } : 'repeat(1, 1fr)'}
          gap='6'
          p='3'
          justifyItems='center' alignItems='center'>
          {postulableEventsList && postulableEventsList.length > 0 ? postulableEventsList.map(event => (
            <Box key={event.id}>          
              <Box flexDirection='column' w={{base:'50vw', md:'35vw', lg:'20vw'}} textAlign='center' key={event.id}  onClick={() => handlePostulationFormOpen(event.id)}>                          
                  <Heading py='2' size='sm'>{event.name}</Heading>
                  <Image src={Postulable} alt={event.name} borderRadius='md'/>              
              </Box>   
              {openEventFormId === event.id && (
                <PostulationForm isOpen={true} onClose={handlePostulationFormClose} eventVocations={event.vocations} eventId={event.id} eventData={event}/>
              )}
            </Box>                  
          )) :           
            <Text fontSize='4xl'>No hay eventos disponibles. </Text>             
        }
        </CardBody>        
    </Card>
  )
}

export default PostulableEvents