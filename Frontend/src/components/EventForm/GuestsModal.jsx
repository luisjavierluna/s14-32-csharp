import { Box, FormControl, FormLabel, IconButton, NumberDecrementStepper, NumberIncrementStepper, NumberInput, NumberInputField, NumberInputStepper, useBreakpointValue } from "@chakra-ui/react"
import { EventInfoModalBtn, EventModal } from "../index"
import { HiOutlineUserGroup, CheckIcon } from "../../assets/icons"
import { useState } from "react"

export default function GuestsModal({guests, setGuests}) {
    const [isGuestsModalOpen, setIsGuestsModalOpen] = useState(false)
    const [eventGuests, setEventGuests] = useState(0)
    
    const handleGuestsModalOpen = () => {setIsGuestsModalOpen(true)}
    const handleGuestsModalClose = () => {setIsGuestsModalOpen(false)} 

    const handleEventGuests = (value) => {
        setEventGuests(value)
        setGuests(value)
    }

    const breakpointValue = useBreakpointValue({ base: 'base', md: 'md' })

    return(
        <Box>        
            <EventInfoModalBtn icon={<HiOutlineUserGroup size='30' />} onClick={handleGuestsModalOpen} text={breakpointValue === 'base' ?(eventGuests > 0 ? eventGuests : (guests ? guests : 'Invitados')) : (eventGuests > 0 ? eventGuests :(guests ? guests : 'Cantidad de invitados'))} />
            <EventModal isOpen={isGuestsModalOpen} onClose={handleGuestsModalClose} title="Seleccionar la cantidad de invitados" onSelect={handleEventGuests}>                          
                <FormControl>
                    <FormLabel>Cantidad total de invitados</FormLabel>
                    <Box display='flex' gap='2'>
                        <NumberInput max={1000000} min={0} clampValueOnBlur={false} value={eventGuests} onChange={handleEventGuests} w='full'>
                            <NumberInputField />
                            <NumberInputStepper>
                                <NumberIncrementStepper />
                                <NumberDecrementStepper />
                            </NumberInputStepper>
                        </NumberInput>
                        <IconButton aria-label='Search database' icon={<CheckIcon />} onClick={handleGuestsModalClose}/>
                    </Box>                         
                </FormControl>                            
            </EventModal>
        </Box>
    )
}