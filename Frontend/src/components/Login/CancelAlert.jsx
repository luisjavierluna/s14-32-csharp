import {
    AlertDialog,
    AlertDialogBody,
    AlertDialogFooter,
    AlertDialogHeader,
    AlertDialogContent,
    AlertDialogOverlay,
    AlertDialogCloseButton,
    useDisclosure, 
    Button,
    IconButton
} from '@chakra-ui/react'
import { useRef } from 'react'
import { FiTrash2 } from "../../assets/icons"
import { Link } from 'react-router-dom'

  export default function CancelAlert({ navlink }) {
    const { isOpen, onOpen, onClose } = useDisclosure()
    const cancelRef = useRef()
  
    return (
      <>
        <IconButton onClick={onOpen} bg='rgba(224, 7, 7, .47)' color='white' borderRadius='full'>
          <FiTrash2 />
        </IconButton>
        <AlertDialog
          motionPreset='slideInBottom'
          leastDestructiveRef={cancelRef}
          onClose={onClose}
          isOpen={isOpen}
          isCentered
        >
          <AlertDialogOverlay />  
          <AlertDialogContent>
            <AlertDialogHeader>¿Desea cancelar el registro?</AlertDialogHeader>
            <AlertDialogCloseButton />
            <AlertDialogBody>Se perderán todos los datos y deberá volver a cargarlos.</AlertDialogBody>
            <AlertDialogFooter>
              <Button ref={cancelRef} onClick={onClose} w='12'>NO</Button>
              <Link to={navlink}><Button colorScheme='red' ml={3} w='12'>SI</Button></Link>               
            </AlertDialogFooter>
          </AlertDialogContent>
        </AlertDialog>
      </>
    )
  }