import { Avatar, AvatarBadge, Box, Button, Input, Image, Modal, useDisclosure, ModalOverlay, ModalContent, ModalCloseButton, ModalBody, ModalFooter } from "@chakra-ui/react"
import axios from 'axios'

const AvatarModal = ({ profileImage, contractorProfileImage }) => {  
  
  const { isOpen, onOpen, onClose } = useDisclosure()  

  const handleImgSubmit = async () => {
    const clientImage = localStorage.getItem('profileImage')    

    const imageInput = document.querySelector('input[type="file"]')
    if (!imageInput || !imageInput.files || imageInput.files.length === 0) {
        console.error('No se ha seleccionado ningún archivo')
        return
    }  
    const imageUpload = imageInput.files[0]      
    try {          
        const formData = new FormData()
        formData.append('file', imageUpload)  
        const response = await axios.post('https://www.eventplanner.somee.com/api/ProfileImage', formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            }
        })
        console.log(response.data)
        clientImage && clientImage.trim() !== '' && clientImage !== 'undefined' && clientImage !== 'url_de_la_imagen' ? localStorage.setItem('profileImage',response.data) : localStorage.setItem('contractorProfileImage', response.data)
        onClose()
        window.location.reload()
    } catch (error) {
        console.error('Error al subir imagen:', error.message)
    }
  }

  return (
    <Box>        
      <Avatar
        size='md'
        ml='3'
        mt='2'
        cursor='pointer'
        src={contractorProfileImage ? contractorProfileImage : profileImage}
        onClick={onOpen}>
        <AvatarBadge boxSize='1.25em' bg='green.500'/>
      </Avatar>
      
        <Modal isOpen={isOpen} onClose={onClose} size='md' motionPreset='slideInBottom' isCentered>
            <ModalOverlay />
            <ModalContent py='6'>
                <ModalCloseButton />
                <ModalBody display='flex' justifyContent='center' alignItems='center' p='4'>
                    <Image src={contractorProfileImage ? contractorProfileImage : profileImage} borderRadius='xl' boxSize='xs' />
                </ModalBody>    
                <ModalFooter>
                    <Input placeholder='Seleccionar Archivo' size='sm' w='100%' type='file' accept=".jpg, .jpeg, .png, .webp"  border='none'/>
                    <Button variant='outline' borderRadius='3xl' fontSize='xs' boxSize='fit-content' color='#CC949F' py='1' onClick={handleImgSubmit}>Cargar Foto</Button>
                </ModalFooter>
            </ModalContent>
        </Modal>      
    </Box>
  )
}

export default AvatarModal
