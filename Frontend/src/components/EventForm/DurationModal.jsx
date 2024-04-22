import { Box, FormControl, FormLabel, IconButton, NumberDecrementStepper, NumberIncrementStepper, NumberInput, NumberInputField, NumberInputStepper, useBreakpointValue } from "@chakra-ui/react"
import { EventInfoModalBtn, EventModal } from "../index"
import { TbClockHour8, CheckIcon } from "../../assets/icons"
import { useState } from "react"

export default function DurationModal({duration, setDuration}) {
    const [isDurationModalOpen, setIsDurationModalOpen] = useState(false)
    const [eventDuration, setEventDuration] = useState(0)
    
    const handleDurationModalOpen = () => {setIsDurationModalOpen(true)}
    const handleDurationModalClose = () => {setIsDurationModalOpen(false)}

    const handleEventDuration = (value) => {
        setEventDuration(value)
        setDuration(value)
    }

    const breakpointValue = useBreakpointValue({ base: 'base', md: 'md' })

    return(
        <Box>        
            <EventInfoModalBtn icon={<TbClockHour8 size='30' />} text={breakpointValue === 'base' ?(eventDuration > 0 ? eventDuration + 'hs':'Duración') : (eventDuration > 0 ? eventDuration + 'hs':'Duración del evento')} onClick={handleDurationModalOpen}/>
            <EventModal isOpen={isDurationModalOpen} onClose={handleDurationModalClose} title="Seleccionar la duración del evento" onSelect={handleEventDuration}>                        
                <FormControl>
                    <FormLabel>Cantidad de horas</FormLabel>
                    <Box display='flex' gap='2'>
                        <NumberInput max={50} min={0} clampValueOnBlur={false} value={eventDuration} onChange={handleEventDuration} w='full'>
                            <NumberInputField />
                            <NumberInputStepper>
                                <NumberIncrementStepper />
                                <NumberDecrementStepper />
                            </NumberInputStepper>
                        </NumberInput>
                        <IconButton aria-label='Search database' icon={<CheckIcon />} onClick={handleDurationModalClose}/>
                    </Box>                       
                </FormControl>
            </EventModal>
        </Box>
    )
}