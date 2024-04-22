import { Box, Button, Card, CardBody, CardFooter, CardHeader, Center, Flex, Heading, Image } from "@chakra-ui/react"
/* import axios from "axios" */
import { /* useEffect, */ useState } from "react"
import { Link } from "react-router-dom"
import EventForm from '../../assets/eventform.png'
import {  HiOutlinePlusCircle } from '../../assets/icons'


const PostulationsHistoryCard = () => {
  const [postulationsCreated, setPostulationsCreated] = useState([])

  /* useEffect(() => {
    const fetchPostulationsCreated = async () => {
      try {
        const token = localStorage.getItem('token')        
        const response = await axios.get('https://www.eventplanner.somee.com/api/',{
          headers: {
              Authorization: `Bearer ${token}`
          }
        })        
        setPostulationsCreated(response.data)
      } catch (error) {
        console.error('Error al obtener historial de postulaciones:', error.message)
      }
    }
    fetchPostulationsCreated()
  }, [])  */
   
  const handleEventClick = () => {
    console.log('Click')
  }
  return (
    <Card bg='rgba(180, 224, 223, .2)' color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='full' boxShadow='xl' minH='80%'>          
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
          {postulationsCreated.map(event => (
            <Box key={event.id} onClick={() => handleEventClick(event)} flexDirection='column' w={{base:'50vw', md:'35vw', lg:'20vw'}} textAlign='center'>                          
                <Heading py='2' size='sm'>{event.name}</Heading>
                <Image src={EventForm} alt={event.name} borderRadius='md'/>              
            </Box>
          ))}          
          <Center flexDirection='column' w='52' h='52' mt='-2'>
              <Button as={Link} to='/eventform' color='#263049' variant='ghost' py='2' borderRadius='md'>
                <Flex align='center' flexDirection='column' gap='2'>
                  <Heading size='sm' ml='2'>Nueva Postulación</Heading>
                  <HiOutlinePlusCircle size={20} />                  
                </Flex>
              </Button>
            </Center>
          
        </CardBody>
        <CardFooter >            
            
        </CardFooter>
    </Card>
  )
}

export default PostulationsHistoryCard