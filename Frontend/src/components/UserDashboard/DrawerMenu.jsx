// DrawerMenu.jsx
import { Box, Drawer, DrawerBody, DrawerContent, DrawerHeader, IconButton, Text, useDisclosure } from "@chakra-ui/react"
import { HiOutlineMenu } from '../../assets/icons'
import { useUserAuth } from '../../context/UserAuthContext'
import AvatarModal from "./AvatarModal"

export default function DrawerMenu({ placement, children, title }) {
    const { isOpen, onOpen, onClose } = useDisclosure()    
     
    const { userName } = useUserAuth()
    const userNameB = localStorage.getItem('userName') 
    const profileImage = localStorage.getItem('profileImage')
    const contractorProfileImage = localStorage.getItem('contractorProfileImage')  
    
  
    return (
        <>
            <IconButton variant='ghost' onClick={onOpen} icon={<HiOutlineMenu size={20}/>}/>
            <Drawer placement={placement} onClose={onClose} isOpen={isOpen}>                 
                <DrawerContent p='1' bg='#FAEDED' h='80vh' mt='10vh'>
                    <Box display='flex' alignItems='center'>
                        <AvatarModal contractorProfileImage={contractorProfileImage} profileImage={profileImage}/>
                        <Text px='6' pt='4'>Hola,<br />
                            <Text as='b'>{userName ? userName : (userNameB ? userNameB : 'Usuario')}!</Text>
                        </Text>
                    </Box>
                    <DrawerHeader p='2' ml='4' mt='4'>{title}</DrawerHeader>
                    <DrawerBody mt='-4' p='2'>
                        {typeof children === 'function' ? children({ onClose }) : children}
                    </DrawerBody>
                </DrawerContent>
            </Drawer>
        </>
    )
}
