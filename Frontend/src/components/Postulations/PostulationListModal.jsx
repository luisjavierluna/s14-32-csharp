import { Box, Card, Heading, CardBody, CardFooter, Text, Button, Image } from '@chakra-ui/react';
import { useEffect, useState } from 'react';
import { HiOutlineCurrencyDollar, HiOutlineGlobe, HiOutlinePhone, MdMailOutline } from '../../assets/icons';
import ImageAvatar from '../../assets/avatar.png';
import axios from 'axios';

const PostulationListModal = ({ postulations, isOpen, onClose }) => {
    const [contractors, setContractors] = useState([]);
    const [postulationData, setPostulationData] = useState()

    useEffect(() => {
        fetchData();
    }, [postulations])

    const fetchData = async () => {
        try {
            const token = localStorage.getItem('token')
    
            const responseContractors = await axios.get('https://www.eventplanner.somee.com/api/Contractor/GetAll', {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
    
            const filteredContractors = responseContractors.data.filter(contractor =>
                postulations.map(postulation => postulation.contractorId).includes(contractor.id)
            )
    
            setContractors(filteredContractors)
    
            const responsePostulations = await axios.get('https://www.eventplanner.somee.com/api/Postulation/GetAll', {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
    
            const filteredPostulations = responsePostulations.data.filter(postulation =>
                postulations.map(post => post.id).includes(postulation.id)
            )
            console.log('postulationdata!', filteredPostulations)
            setPostulationData(filteredPostulations)
        } catch (error) {
            console.error('Error al obtener información del evento:', error.message)
        }
    }
    

    const handleAccept = async (id) => {
        try {
            const token = localStorage.getItem('token')
            const response = await axios.put(`https://www.eventplanner.somee.com/api/Postulation/accept/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
            console.log('Respuesta Accept: ', response)
            fetchData()
        } catch (error) {
            console.error('Error al enviar los cambios:', error.message)
        }
    };

    const handleRefuse = async (id) => {
        try {
            const token = localStorage.getItem('token');
            const response = await axios.put(`https://www.eventplanner.somee.com/api/Postulation/refuse/${id}`, {
                headers: {
                    Authorization: `Bearer ${token}`
                }
            })
            console.log('Respuesta Refuse: ', response)
            fetchData()
        } catch (error) {
            console.error('Error al enviar los cambios:', error.message)
        }
    };

    const renderPostulations = () => {
        return postulations.map((postulation, index) => {
            const contractor = contractors.find(contractor => contractor.id === postulation.contractorId)

            return (
                <CardBody key={index} width='100%' mt='-4' fontFamily='body' px='6' display='flex' flexDirection='column'>
                    <Box>
                        <Heading size='lg' fontFamily='heading'>{postulation.vocationName || 'Especialidad'}</Heading>
                    </Box>
                    <Box key={index} display='flex' flexDirection={{base:'column', md:'row'}} justifyContent='center' alignItems='center' gap='4' mt='8'>
                        <Box>
                            <Image src={contractor?.profileImage || ImageAvatar} borderRadius='xl' w={{base:'52', md:'60'}} h={{base:'52', md:'60'}} />
                        </Box>
                        <Box w={{base:'52', md:'60'}} h={{base:'52', md:'60'}} bg='rgba(204, 148, 159, .2)' borderRadius='xl' p='2' display='flex' flexDirection='column' justifyContent='space-evenly'>
                            <Box>
                                <Text textAlign='center' fontSize='xl' fontWeight='semibold'>{contractor?.businessName || 'Razon Social'}</Text>
                            </Box>                            
                            <Text h='10vh' overflowY='scroll'>{postulationData?postulationData[0].message : 'Mensaje de la postulación...'}</Text>
                            <Box display='flex' alignItems='center' gap='2'>
                                <HiOutlineCurrencyDollar size='25' />
                                <Text>{postulation.budget || '30000'}</Text>
                            </Box>
                            <Box display='flex' alignItems='center' gap='2'>
                                <HiOutlineGlobe size='25' />
                                <Text>{contractor?.link || 'Sitio Web'}</Text>
                            </Box>
                            <Box display='flex' alignItems='center' gap='2'>
                                <HiOutlinePhone size='25' />
                                <Text>1589623678</Text>
                            </Box>
                            <Box display='flex' alignItems='center' gap='2'>
                                <MdMailOutline size='25' />
                                <Text>usuario@usuario.com</Text>
                            </Box>
                        </Box>
                    </Box>
                    <CardFooter display='flex' gap='2' width='100%' alignItems='center' justifyContent='center' >
                        <Button bg='#263049' color='white' w='24' onClick={() => handleAccept(postulation.id)}>Contratar</Button>
                        <Button bg='rgba(224, 7, 7, .47)' color='white' w='24' onClick={() => handleRefuse(postulation.id)}>Rechazar</Button>
                    </CardFooter>
                </CardBody>
            )
        })
    }

    return (
        <Box display={isOpen ? 'block' : 'none'} position="fixed" zIndex="9999" top="0" bottom="0" left="0" right="0" bg="rgba(0, 0, 0, 0.5)" onClick={onClose}>
            <Card position="absolute" top="50%" left="50%" transform="translate(-50%, -50%)" width="90%" maxWidth="600px" bg="white" p='4' borderRadius="3xl" boxShadow="lg" onClick={(e) => e.stopPropagation()} color='#263049' flexDirection='column' alignItems='center' minH='50vh' maxH='80vh' overflowY='scroll'>
                {renderPostulations()}
            </Card>
        </Box>
    );
};

export default PostulationListModal;
