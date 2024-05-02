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

    const formatDate = (dateTime) => {
        const [year, month, day] = dateTime.split('T')[0].split('-')
        return `${day}-${month}-${year}`
    }
    const formattedTime = (timeString) => {        
        const [hour, minute] = timeString.split('T')[1].split(':')
        return `${hour}:${minute}hs`
    }

    const handleDateTimeSelect = (dateTime) => {
        console.log(dateTime)
        setSelectedDate(formatDate(dateTime)) 
        setSelectedTime(dateTime.split('T')[1])         
        setDate(dateTime + ':00.000Z')
    }    

    const breakpointValue = useBreakpointValue({ base: 'base', md: 'md' })

    return(
        <>
            <Box >        
                <EventInfoModalBtn icon={<HiOutlineCalendar size='30' />} 
                text={breakpointValue === 'base' ? (selectedDate ? `${selectedDate} ${selectedTime}hs` : (date ? date : 'Fecha')) : (selectedDate ? selectedDate : (date ? formatDate(date) :'Fecha del evento'))}
                onClick={handleDateModalOpen} />
                <EventModal isOpen={isDateModalOpen} onClose={handleDateModalClose} title="Seleccionar la fecha y hora del evento" onSelect={handleDateTimeSelect}>
                    <Box display='flex' gap='2'>
                        <Input placeholder='Seleccionar fecha y hora' size='md' type='datetime-local' onChange={(e) => handleDateTimeSelect(e.target.value)} />
                        <IconButton aria-label='Search database' icon={<CheckIcon />} onClick={handleDateModalClose}/>
                    </Box>
                </EventModal> 
            </Box>
            <Box display={{ base: 'none', md: 'block' }}>
                <EventInfoModalBtn icon={<TbClockHour4 size='30' />} text={selectedTime ? selectedTime + 'hs' : (date? formattedTime(date) : 'Hora de inicio')} onClick={handleDateModalOpen} />                      
            </Box> 
        </>
    )
}