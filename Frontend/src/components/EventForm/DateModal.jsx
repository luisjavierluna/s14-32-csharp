import { Box, IconButton, Input, useBreakpointValue } from "@chakra-ui/react"
import { EventInfoModalBtn, EventModal } from "../index"
import { HiOutlineCalendar, TbClockHour4, CheckIcon } from "../../assets/icons"
import { useState } from "react"

export default function DateModal({date, setDate}) {
    const [isDateModalOpen, setIsDateModalOpen] = useState(false)    
    const [selectedDate, setSelectedDate] = useState("")
    const [selectedTime, setSelectedTime] = useState("")
    
    const handleDateModalOpen = () => {setIsDateModalOpen(true)}
    const handleDateModalClose = () => {setIsDateModalOpen(false)}

    const handleDateTimeSelect = (dateTime) => {
        console.log(dateTime)        
        const [year, month, day] = dateTime.split('T')[0].split('-');
        setSelectedDate(`${day}-${month}-${year}`) 
        setSelectedTime(dateTime.split('T')[1])         
        setDate(dateTime + ':00.000Z')
    }

    const breakpointValue = useBreakpointValue({ base: 'base', md: 'md' })

    return(
        <>
            <Box >        
                <EventInfoModalBtn icon={<HiOutlineCalendar size='30' />} 
                text={breakpointValue === 'base' ? (selectedDate ? `${selectedDate} ${selectedTime}hs` : 'Fecha') : (selectedDate ? selectedDate : 'Fecha del evento')}
                onClick={handleDateModalOpen} />
                <EventModal isOpen={isDateModalOpen} onClose={handleDateModalClose} title="Seleccionar la fecha y hora del evento" onSelect={handleDateTimeSelect}>
                    <Box display='flex' gap='2'>
                        <Input placeholder='Seleccionar fecha y hora' size='md' type='datetime-local' onChange={(e) => handleDateTimeSelect(e.target.value)} />
                        <IconButton aria-label='Search database' icon={<CheckIcon />} onClick={handleDateModalClose}/>
                    </Box>
                </EventModal> 
            </Box>
            <Box display={{ base: 'none', md: 'block' }}>
                <EventInfoModalBtn icon={<TbClockHour4 size='30' />} text={selectedTime ? selectedTime + 'hs' : 'Hora de inicio'} onClick={handleDateModalOpen} />                      
            </Box> 
        </>
    )
}