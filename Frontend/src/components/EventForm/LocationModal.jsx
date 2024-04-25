import { Box, FormControl, FormLabel, Input, Select, useBreakpointValue } from "@chakra-ui/react"
import { EventInfoModalBtn, EventModal } from "../index"
import { HiOutlineGlobe } from "../../assets/icons"
import { useEffect, useState } from "react"
import axios from "axios"

export default function LocationModal({location, setLocation}) {
    const [isLocationModalOpen, setIsLocationModalOpen] = useState(false)
    const [provinces, setProvinces] = useState([])
    const [cities, setCities] = useState([])   
    const [address, setAddress] = useState('')

    const handleLocationModalOpen = () => {setIsLocationModalOpen(true)}
    const handleLocationModalClose = () => {setIsLocationModalOpen(false)}

    const breakpointValue = useBreakpointValue({ base: 'base', md: 'md' })    
      
    const handleAddressChange = (event) => {
        const address = event.target.value
        setAddress(address)
        setLocation(prevLocation => ({ ...prevLocation, address: address }))
    }

    const handleProvinceChange = async (event) => { 
        const selectedProvinceName = event.target.value
        const selectedProvinceId = provinces.find(province => province.name === selectedProvinceName)
        try {
            const token = localStorage.getItem('token')
            const response = await axios.get(`https://www.eventplanner.somee.com/api/Cities?provinceId=${selectedProvinceId.id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })           
            setCities(response.data)
        } catch (error) {
            console.error('Error al solicitar las ciudades:', error.message)
        }
    }

    const handleCityChange = (event) => {
        const selectedCity = event.target.value        
        setLocation(prevLocation => ({ ...prevLocation, cityId: selectedCity}))
    } 
    

    useEffect(() => {
        const handleLocations = async () => {
            try {
                const token = localStorage.getItem('token')
                const response = await axios.get('https://www.eventplanner.somee.com/api/Cities/provinces', {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });                
                setProvinces(response.data)                              
            } catch (error) {
                console.error('Error al solicitar las provincias:', error.message)
            }
        }
        handleLocations()
    }, [])

    return(
        <Box>        
            <EventInfoModalBtn icon={<HiOutlineGlobe size='30' />} text={breakpointValue === 'base' ?(address ? address : (location.address ? location.address : 'Ubicación')) : (address ? address : (location.address ? location.address : 'Ubicación del evento'))} onClick={handleLocationModalOpen} />
            <EventModal isOpen={isLocationModalOpen} onClose={handleLocationModalClose} title="Seleccionar la ubicación del evento" onSelect={handleAddressChange}>
                <FormControl display='flex' flexDirection='column' gap='6'>
                    <Box>
                        <FormLabel ml='1'>Seleccionar Provincia</FormLabel>
                        <Select placeholder='Seleccionar Provincia'  mt='-2' onChange={handleProvinceChange}>
                            {provinces.map(province => (
                                <option key={province.id} value={province.name}>{province.name}</option>
                            ))}
                        </Select>
                    </Box>
                    <Box>
                        <FormLabel ml='1'>Seleccionar Ciudad</FormLabel>
                        <Select placeholder='Seleccionar Ciudad' mt='-2' onChange={handleCityChange}> 
                            {cities.map(city => (
                                <option key={city.id} value={city.id}>{city.name}</option>
                            ))}
                        </Select> 
                    </Box>
                    <Box>
                        <FormLabel ml='1'>Indicar Dirección</FormLabel>
                        <Input type='text' mt='-2' value={address} onChange={handleAddressChange}/>
                    </Box>                      
                </FormControl>
            </EventModal>
        </Box>
    )
}