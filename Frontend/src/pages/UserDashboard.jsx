import { Box, Container, Image, Link, Text, IconButton, List, ListItem, Button } from "@chakra-ui/react"
import { EventsHistoryCard, PostulationsHistoryCard, DrawerMenu } from "../components"
import { HiOutlineBell } from '../assets/icons'
import PinkBalloon from '../assets/pinkballoonhand.png'
import { useState } from "react"

const UserDashboard = () => {   
    const [selectedMenuItem, setSelectedMenuItem] = useState(null)

    const handleMenuItemClick = (menuItem) => {
        setSelectedMenuItem(menuItem)
    }

  return (
    <Container display='flex' minW='100%' bg='rgba(180, 224, 223, .2)' pr='-2'>
        <Box display='flex' flexDirection='column' alignItems='center' w='full' p='2' pr='4'>
            <Box display='flex' justifyContent='space-between' w='full' pb='2'>
                <DrawerMenu placement='left' title='Menú'>
                    <List display='flex' flexDirection='column' gap='2' >
                        <ListItem><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }}>Quiero ser Proveedor</Button></ListItem>
                        <ListItem><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} onClick={() => handleMenuItemClick('events')}>Mis Eventos</Button></ListItem>
                        {/* condicional dependiendo tipo de usuario */}
                        <ListItem><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} onClick={() => handleMenuItemClick('postulations')}>Mis Postulaciones</Button></ListItem>
                    </List>
                </DrawerMenu>
                <IconButton variant='ghost' aria-label='Notifications' icon={<HiOutlineBell  size={20}/>}/>
            </Box>
            {selectedMenuItem === 'postulations' ? <PostulationsHistoryCard /> : <EventsHistoryCard />}            
            {selectedMenuItem === 'events' || selectedMenuItem === null && <Text fontSize='xs' padding='2' mt='3'>¿Ofreces un servicio? ¡Haz para <Link fontSize='xs' fontWeight='700' color='#263049' href='/contractorform'>click aquí</Link> completar tus datos y comienza a enviar presupuestos!</Text>}
        </Box>        
        <Image src={PinkBalloon} alt='Globo Rosa' h={`calc(100vh - 96px)`}/>
    </Container>
  )
}

export default UserDashboard