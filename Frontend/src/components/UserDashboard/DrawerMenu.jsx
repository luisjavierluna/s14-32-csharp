import { Avatar, AvatarBadge, Box, Drawer, DrawerBody, DrawerContent, DrawerHeader, IconButton, Text, useDisclosure } from "@chakra-ui/react"
import { HiOutlineMenu } from '../../assets/icons'
import { useUserAuth } from '../../context/UserAuthContext'

export default function DrawerMenu({ placement, children, title }) {
    const { isOpen, onOpen, onClose } = useDisclosure()    
     
    const userNameB = localStorage.getItem('userName') 
    const { userName } = useUserAuth()
  
    return (
      <>        
        <IconButton variant='ghost' onClick={onOpen}  icon={<HiOutlineMenu size={20}/>}/>         
        <Drawer placement={placement} onClose={onClose} isOpen={isOpen}>                 
          <DrawerContent p='1' bg='#FAEDED' h={`calc(100vh - 96px)`} mt='96px'>
            <Box display='flex' alignItems='center'>
              <Avatar size='md' ml='3' mt='2'><AvatarBadge boxSize='1.25em' bg='green.500'/></Avatar>
              <Text px='6' pt='4'>Hola,<br />
                <Text as='b'>{userName ? userName : (userNameB ? userNameB : 'Usuario')}!</Text>
              </Text>
            </Box>
            <DrawerHeader p='2' ml='4' mt='4'>{title}</DrawerHeader>
            <DrawerBody mt='-4' p='2'>
              {children}
            </DrawerBody>
          </DrawerContent>
        </Drawer>
      </>
    )
}