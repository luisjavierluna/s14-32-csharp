import { Button, Text } from '@chakra-ui/react'

const EventInfoModalBtn = ({ icon, text, onClick }) => {
  return (
    <Button variant='ghost' colorScheme='white' display='flex' flexDirection='column' alignItems='center' onClick={onClick} h={{base:'14', md:'12'}} w={{base:'16', sm:'20', md:'36'}}>
      {icon}
      <Text border='1px' borderRadius='md' fontSize={{base:'xs', md:'sm'}} px='2' color='gray.500' fontWeight='300' w={{base:'16', md:'36'}} >{text}</Text>
    </Button>
  )
}

export default EventInfoModalBtn