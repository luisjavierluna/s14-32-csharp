// UserDashboard.jsx
import { Box, Container, Image, Link, Text, IconButton, List, ListItem, Button } from "@chakra-ui/react"
import { EventsHistoryCard, PostulationsHistoryCard, DrawerMenu } from "../components"
import { HiOutlineBell } from '../assets/icons'
import PinkBalloon from '../assets/pinkballoonhand.png'
import { useState } from "react"
import { useNavigate } from "react-router-dom"

const UserDashboard = () => {   
    const userRole = localStorage.getItem('role') 
    const [selectedMenuItem, setSelectedMenuItem] = useState(userRole === 'contractor'? 'postulations' : '')
    const navigate = useNavigate()
    const handleMenuItemClick = (menuItem) => {
        setSelectedMenuItem(menuItem)
    }

    const handleClick = () => {
        navigate('/contractorform')
    }

    return (
        <Container display='flex' minW='100%' bg='rgba(180, 224, 223, .2)' pr='-2' minH='80vh'>
            <Box display='flex' flexDirection='column' alignItems='center' w='full' p='2' pr='4'>
                <Box display='flex' justifyContent='space-between' w='full' pb='2'>
                    <DrawerMenu placement='left' title='Menú'>
                        {({ onClose }) => (
                            <List display='flex' flexDirection='column' gap='2' >
                                {userRole === 'client' &&
                                <ListItem><Button onClick={handleClick} variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} >Quiero ser Proveedor</Button></ListItem>}
                                <ListItem><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} onClick={() => { handleMenuItemClick('events'); onClose(); }}>Mis Eventos</Button></ListItem>
                                {userRole === 'contractor' &&
                                <ListItem><Button variant='ghost' w='full' display='flex' justifyContent='flex-start' _hover={{ bg: 'rgba(204, 148, 159, .3)' }} onClick={() => { handleMenuItemClick('postulations'); onClose(); }}>Mis Postulaciones</Button></ListItem>}
                            </List>
                        )}
                    </DrawerMenu>
                    <IconButton variant='ghost' aria-label='Notifications' icon={<HiOutlineBell  size={20}/>}/>
                </Box>
                {selectedMenuItem === 'postulations' ? <PostulationsHistoryCard /> : <EventsHistoryCard />}            
                <Text fontSize='xs' padding='2' mt='3'display={userRole === 'contractor'? 'none' : 'block'} >¿Ofreces un servicio? ¡Haz para <Link fontSize='xs' fontWeight='700' color='#263049' href='/contractorform'>click aquí</Link> completar tus datos y comienza a enviar presupuestos!</Text>
            </Box>        
            <Image src={PinkBalloon} alt='Globo Rosa' h='80vh' display={{base:'none', md:'block'}}/>
        </Container>
    )
}

export default UserDashboard
