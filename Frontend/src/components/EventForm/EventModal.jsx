import { Modal, ModalOverlay, ModalContent, ModalHeader, ModalCloseButton, ModalBody } from '@chakra-ui/react'
import { cloneElement } from 'react';

const EventModal = ({ isOpen, onClose, onSelect, title, children }) => {

  const handleInputChange = (event) => {
    const newValue = event.target.value;
    onSelect(newValue); // Llama a la función onSelect con el nuevo valor seleccionado
  };
  
  return (
    <Modal isOpen={isOpen} onClose={onClose} isCentered>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>{title}</ModalHeader>
        <ModalCloseButton />
        <ModalBody>
            {cloneElement(children, { onChange: handleInputChange })}       
        </ModalBody>
      </ModalContent>
    </Modal>
  );
};

export default EventModal