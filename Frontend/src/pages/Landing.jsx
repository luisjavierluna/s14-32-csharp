import { Box, Button, Grid, Heading, Image, Text } from "@chakra-ui/react"
import Balloons from '../assets/ballons.jpeg'
import BalloonsPink from '../assets/ballons-pink.jpeg'
import EventForm from '../assets/eventform.png'
import { LoginButton, ReviewCard, FAQCarousel } from "../components"
import { useState } from "react"


export default function Landing () {
    const [isClicked, setIsClicked] = useState(true);

  const handleClick = () => {
    setIsClicked(!isClicked);
  };
    return (
      <>
        <Box bgImage={Balloons} bgPosition='right' bgRepeat="no-repeat" bgSize='cover' minH='90vh' display='flex' alignItems='center'>
            <Box w={{base:'100%', lg:'60%'}} display='flex' flexDirection='column' gap='6' alignItems='center'>
                <Heading size={{base:'lg',sm:'2xl'}} fontFamily='heading'>
                    ¿Necesitas organizar un evento? 
                </Heading>                
                <Heading size={{base:'lg',sm:'2xl'}} fontFamily='heading'>
                    Event Planner lo hace por vos!
                </Heading>                 
                <Box w='fit-content'>
                    <LoginButton bgcolor='#263049' color='white' name='CREAR EVENTO'/>
                </Box>
            </Box>
        </Box>
        <Box minH='80vh' p='2'>
                <Box textAlign='center'>
                    <Heading py='4' fontFamily='heading'>¿Cómo Funciona?</Heading> 
                    <Button
                        bg="#CFE4E4"
                        opacity={isClicked? '1' : '.5'}
                        color="#263049"
                        borderTopLeftRadius="full"
                        borderBottomLeftRadius="full"
                        borderTopRightRadius="0"
                        borderBottomRightRadius="0"
                        onClick={handleClick}
                        py={{base:'2', md:'6'}}
                        px={{base:'4', md:'8'}}
                        fontSize={{base:'md', md:'lg'}} 
                        >
                        Organizadores
                    </Button>
                    <Button
                        bg="#CFE4E4"
                        opacity={isClicked? '.5' : '1'}
                        color="#263049" 
                        borderTopRightRadius="full"
                        borderBottomRightRadius="full" 
                        borderTopLeftRadius="0"
                        borderBottomLeftRadius="0"
                        onClick={handleClick}  
                        py={{base:'2', md:'6'}}
                        px={{base:'4', md:'8'}}
                        fontSize={{base:'md', md:'lg'}}               
                        >
                        Proveedores
                    </Button>                   
                </Box>                
                <Box display={{ base: "block", sm: "none" }} mt='4' fontFamily='body' fontWeight='semibold'>
                    <Grid
                        templateColumns="1fr 1fr"
                        templateRows="repeat(3, auto)"
                        gap={4}
                        width="100%">                        
                        <Box display="flex" alignItems="center" justifyContent="center" gap='2'>
                            <Box
                                gridColumn="1"
                                gridRow="1"
                                bg="#CFE4E4"
                                borderRadius="full"
                                w="12"
                                h="12"
                                py="1"
                                px="4"
                                fontSize="2xl"
                                display="flex"
                                alignItems="center"
                                justifyContent="center"
                            >
                                1
                            </Box>
                            {!isClicked? <Text>Registra tu empresa</Text> : <Text>Crea tu evento</Text>}
                        </Box>
                        <Box display="flex" alignItems="center" justifyContent="center" gap='2'>
                            <Box
                                gridColumn="1"
                                gridRow="3"
                                bg="#CFE4E4"
                                borderRadius="full"
                                w="12"
                                h="12"
                                py="1"
                                px="4"
                                fontSize="2xl"
                                display="flex"
                                alignItems="center"
                                justifyContent="center"
                            >
                                2
                            </Box>
                            {!isClicked? <Text>Envia presupuestos</Text> : <Text>Contrata</Text>}
                        </Box>                        
                        <Box gridColumn="1/ span 2" gridRow="2" display="flex" alignItems="center" justifyContent="center">
                            <Image src={EventForm} alt="ejemplo crear evento" />
                        </Box>
                        <Box display="flex" alignItems="center" justifyContent="center" gap='2'>
                            <Box
                                gridColumn="2"
                                gridRow="1"
                                bg="#CFE4E4"
                                borderRadius="full"
                                w="12"
                                h="12"
                                py="1"
                                px="4"
                                fontSize="2xl"
                                display="flex"
                                alignItems="center"
                                justifyContent="center"
                            >
                                3
                            </Box>
                            {!isClicked? <Text>Responde consultas</Text> : <Text>Recibe propuestas</Text>}
                        </Box>
                        <Box display="flex" alignItems="center" justifyContent="center" gap='2'>
                            <Box
                                gridColumn="2"
                                gridRow="3"
                                bg="#CFE4E4"
                                borderRadius="full"
                                w="12"
                                h="12"
                                py="1"
                                px="4"
                                fontSize="2xl"
                                display="flex"
                                alignItems="center"
                                justifyContent="center"
                            >
                                4
                            </Box>
                            {!isClicked? <Text>Obtén nuevos clientes</Text> : <Text>Disfruta tu evento!</Text>}
                            
                        </Box>
                    </Grid>
                </Box>
                <Box display={{ base: "none", sm: "block" }} mt='4' fontFamily='body' fontWeight='semibold'>
                    <Grid
                        templateColumns="1fr 2fr 1fr"
                        templateRows="repeat(2, auto)"
                        gap={4} 
                        width="100%"
                        >                    
                        <Box gridColumn="1" gridRow="1" display='flex' gap='2' alignItems='center' pl={{base:'2',md:'10',lg:'20', xl:'32'}}>
                            <Box bg='#CFE4E4' borderRadius='full' w='12' h='12' py='1' px='4' fontSize='2xl' display='flex' alignItems='center' justifyContent='center'>1</Box>
                            {!isClicked? <Text>Registra tu empresa</Text> : <Text>Crea tu evento</Text>}
                        </Box>
                        <Box gridColumn="1" gridRow="2" display='flex' gap='2' alignItems='center' pl={{base:'2',md:'10',lg:'20', xl:'32'}}>
                            <Box bg='#CFE4E4' borderRadius='full' w='12' h='12' py='1' px='4' fontSize='2xl' display='flex' alignItems='center' justifyContent='center'>3</Box>
                            {!isClicked? <Text>Envia presupuestos</Text> : <Text>Contrata</Text>}
                        </Box>
                        <Box gridColumn="2" gridRow="1 / span 2" display="flex" alignItems="center" justifyContent="center" p='4'>
                            <Image src={EventForm} alt='ejemplo crear evento'/>
                        </Box>
                        <Box gridColumn="3" gridRow="1" display='flex' gap='2' alignItems='center'>
                            <Box bg='#CFE4E4' borderRadius='full' w='12' h='12' py='1' px='4' fontSize='2xl' display='flex' alignItems='center' justifyContent='center'>2</Box>
                            {!isClicked? <Text>Responde consultas</Text> : <Text>Recibe propuestas</Text>}
                        </Box>
                        <Box gridColumn="3" gridRow="2" display='flex' gap='2' alignItems='center'>
                            <Box bg='#CFE4E4' borderRadius='full' w='12' h='12' py='1' px='4' fontSize='2xl' display='flex' alignItems='center' justifyContent='center'>4</Box>
                            {!isClicked? <Text>Obtén nuevos clientes</Text> : <Text>Disfruta tu evento!</Text>}
                        </Box>
                    </Grid>
                </Box>
        </Box>
        <Box bgImage={BalloonsPink} bgPosition='right' bgRepeat="no-repeat" bgSize='cover' minH='90vh' display='flex' flexWrap='wrap' justifyContent='center' alignItems='center' gap='16' p='8'>
            <ReviewCard text={'Me encantó la aplicación! Pude planificar mi cumpleaños justo como quería!'} stars={5}/>
            <ReviewCard text={'¡Increíble app! Encontré al mejor DJ para mi fiesta en minutos, ¡todo salió perfecto!'} stars={5}/>
            <ReviewCard text={'¡Qué descubrimiento! Organizar una cena empresarial nunca fue tan fácil. ¡Encontré al chef perfecto en un abrir y cerrar de ojos!'} stars={6}/>
        </Box>
        <Box mb='12'>
            <Heading py='14' fontFamily='heading' textAlign='center'>Preguntas frecuentes</Heading>
            <FAQCarousel/>
        </Box>        
      </>
    )
}