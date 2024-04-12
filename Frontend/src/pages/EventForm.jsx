import { Container, AspectRatio, Image, Box, Card, CardHeader, Center, Heading, Link, CloseButton, CardBody, CardFooter, FormControl, FormLabel, Input, ListItem, List, Text, IconButton, Modal, ModalBody, ModalOverlay, ModalContent, ModalHeader, ModalCloseButton, Button } from '@chakra-ui/react'
import CancelAlert from '../components/Login/CancelAlert'
import LoginButton from '../components/Login/LoginButton'
import { HiOutlineTag, HiOutlineCalendar, HiOutlineGlobe } from "react-icons/hi"
import { TbClockHour8, TbClockHour4 } from "react-icons/tb"
import { HiOutlineUserGroup, HiOutlinePlusCircle } from "react-icons/hi2"
import { useState } from 'react'


export default function EventForm () {
  const [isEventModalOpen, setIsEventModalOpen] = useState(false)
  const [selectedEventOption, setSelectedEventOption] = useState(null)
  const [isExpertModalOpen, setIsExpertModalOpen] = useState(false)
  const [selectedExpertOption, setSelectedExpertOption] = useState(null)
  
  //EventsModal
  const eventOptions = [
    "-",
    "Casamiento",
    "Cumpleaños",
    "Bautismo",
    "Baby Shower",
    "Empresarial",
    "Fin de Año",
    "Otro Evento"
  ]
  const handleEventModalOpen = () => {
    setIsEventModalOpen(true)
  }  
  const handleEventModalClose = () => {
    setIsEventModalOpen(false)
  }
  const handleEventOptionClick = (eventOption) => {
    setSelectedEventOption(eventOption)
    handleEventModalClose()
  }

  //ExpertsModal
  const expertOptions = [
    "-",
    "Fotógrafo",
    "Chef",
    "Catering",
    "Dj",
    "Mozos",
    "Animador",
    "Otros"
  ]
  const handleExpertModalOpen = () => {
    setIsExpertModalOpen(true)
  };
  
  const handleExpertModalClose = () => {
    setIsExpertModalOpen(false)
  };
  const handleExpertOptionClick = (expertOption) => {
    setSelectedExpertOption(expertOption)
    handleExpertModalClose()
  }  

return(
<Container minW='100%' minH='100vh' padding='2' bg='rgba(180, 224, 223, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Image src='logo2.png' alt='Logo Event Planner'/>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding='8' >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='80%' boxShadow='xl'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg' fontFamily='heading'>Nuevo Evento</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
          </CardHeader>
          <CardBody width='95%' mt='-4' fontFamily='body'>
            <form>
              <Box display='flex' flexDirection='column' alignItems='center'>
                <Box display='flex' gap='4' width='100%'>
                  <FormControl display='flex' alignItems='center' ml='5' gap='2'>
                    <FormLabel minWidth='140' fontWeight='semibold'>Nombre del Evento</FormLabel>
                    <Input placeholder='Casamiento de Juan' size='sm' borderRadius='md'/>
                  </FormControl>
                  <FormControl display='flex' alignItems='center' gap='1' width='35%'>
                    <HiOutlineTag size='30'/> 
                    <Box position="relative" zIndex="1" width='100%'>
                      <Input
                        value={selectedEventOption === "-" ? "" : selectedEventOption || ""}
                        readOnly
                        onClick={handleEventModalOpen}
                        placeholder="Tipo de evento"
                        textAlign='center'
                        size='sm'
                        borderRadius='md'
                      />
                      <Modal isOpen={isEventModalOpen} onClose={handleEventModalClose} isCentered>
                        <ModalOverlay />
                        <ModalContent>
                          <ModalHeader>Seleccionar tipo de evento</ModalHeader>
                          <ModalCloseButton />
                          <ModalBody>
                            <List cursor='pointer'>
                              {eventOptions.map((eventOption, index) => (
                                <ListItem key={index} onClick={() => handleEventOptionClick(eventOption)}>
                                  <Button variant='ghost' width='100%'>{eventOption}</Button>
                                </ListItem>
                              ))}
                            </List>
                          </ModalBody>
                        </ModalContent>
                      </Modal>                      
                    </Box>                    
                  </FormControl>                  
                </Box>
                <Box width='100%' display='flex' gap='8'>
                  <Box mt='8' display='flex' flexDirection='column' gap='3'>                    
                      <Box as='button' variant='ghost' display='flex' flexDirection='column' alignItems='center'>
                        <HiOutlineCalendar size='30'/>
                        <Text border='1px' borderRadius='md' fontSize='sm' px='3' color='gray.500' fontWeight='300' minWidth='150'>Fecha del evento</Text>
                      </Box>
                      <Box as='button' variant='ghost' display='flex' flexDirection='column' alignItems='center'>
                        <TbClockHour4 size='30'/>
                        <Text border='1px' borderRadius='md' fontSize='sm' px='3' color='gray.500' fontWeight='300' minWidth='150'>Hora de inicio</Text>
                      </Box>
                      <Box as='button' variant='ghost' display='flex' flexDirection='column' alignItems='center'>
                        <TbClockHour8 size='30'/>
                        <Text border='1px' borderRadius='md' fontSize='sm' px='3' color='gray.500' fontWeight='300' minWidth='150'>Duración del evento</Text>
                      </Box>
                      <Box as='button' variant='ghost' display='flex' flexDirection='column' alignItems='center'>
                        <HiOutlineUserGroup size='30'/>
                        <Text border='1px' borderRadius='md' fontSize='sm' px='3' color='gray.500' fontWeight='300' minWidth='150'>Cantidad de invitados</Text>
                      </Box>
                      <Box as='button' variant='ghost' display='flex' flexDirection='column' alignItems='center'>
                        <HiOutlineGlobe size='30'/>
                        <Text border='1px' borderRadius='md' fontSize='sm' px='3' color='gray.500' fontWeight='300' minWidth='150'>Ubicación del evento</Text>
                      </Box>
                  </Box>
                  <Card width='100%' bg='rgba(204, 148, 159, .12)' mt='4' minH='430'>
                  <CardHeader width='100%'>
                    <Center>
                      <Heading as='u' size='md' fontFamily='heading' color='#CC949F'>BÚSQUEDA DE EXPERTOS</Heading>
                    </Center>                    
                  </CardHeader>
                  <CardBody>
                  <FormControl display='flex' alignItems='center' px='20'>
                    <IconButton variant='ghost' colorScheme='teal' aria-label='Call Sage' fontSize='30px' icon={<HiOutlinePlusCircle />}/>                    
                    <Box position="relative" zIndex="1" width='100%'>
                      <Input
                        value={selectedExpertOption === "-" ? "" : selectedExpertOption || ""}
                        readOnly
                        onClick={handleExpertModalOpen}
                        placeholder="Agregar puesto a cubrir"
                        textAlign='center'
                        size='sm'
                        borderRadius='md'
                        bg='white'
                      />
                      <Modal isOpen={isExpertModalOpen} onClose={handleExpertModalClose} isCentered>
                        <ModalOverlay />
                        <ModalContent>
                          <ModalHeader>Seleccionar puesto a cubrir</ModalHeader>
                          <ModalCloseButton />
                          <ModalBody>
                            <List cursor='pointer'>
                              {expertOptions.map((expertOption, index) => (
                                <ListItem key={index} onClick={() => handleExpertOptionClick(expertOption)}>
                                  <Button variant='ghost' width='100%'>{expertOption}</Button>
                                </ListItem>
                              ))}
                            </List>
                          </ModalBody>
                        </ModalContent>
                      </Modal>                       
                    </Box> 
                  </FormControl>
                  </CardBody>
                  </Card>                  
                </Box>
                <Box width='50%' mt='8'>                
                    <LoginButton bgcolor='#263049' color='white' name='CREAR EVENTO' /> 
                </Box>
              </Box>
            </form>
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center' mt='-8'>            
            <CancelAlert />
          </CardFooter>
        </Card>
      </Box>
</Container>
)
}