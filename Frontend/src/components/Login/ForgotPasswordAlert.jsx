import { AlertDialog, AlertDialogBody, AlertDialogCloseButton, AlertDialogContent, AlertDialogFooter, AlertDialogHeader, AlertDialogOverlay, Button, Link, useDisclosure } from "@chakra-ui/react"
import { useRef } from "react"


const ForgotPasswordAlert = () => {
    const { isOpen, onOpen, onClose } = useDisclosure()
    const cancelRef = useRef()

  return (
    <>      
      <Link fontSize='xs' fontWeight='700' color='#263049' onClick={onOpen}>Click aquí para recuperarla.</Link> 
      <AlertDialog
        motionPreset='slideInBottom'
        leastDestructiveRef={cancelRef}
        onClose={onClose}
        isOpen={isOpen}
        isCentered
      >
        <AlertDialogOverlay />
        <AlertDialogContent>
          <AlertDialogHeader>Recuperar Contraseña</AlertDialogHeader>
          <AlertDialogCloseButton />
          <AlertDialogBody>
            Te enviamos tu contraseña por email. Revisa tu bandeja de entrada.
          </AlertDialogBody>
          <AlertDialogFooter>
            <Button ref={cancelRef} onClick={onClose}>
              Cerrar
            </Button>            
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </>
  )
}

export default ForgotPasswordAlert