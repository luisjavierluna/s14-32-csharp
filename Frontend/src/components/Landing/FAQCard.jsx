import { Box, Card, CardBody, CardHeader, Text } from "@chakra-ui/react"

const FAQCard = ({text, title, number}) => {
   

  return (
    <Card p='3' display='flex' flexDirection={{base:'column',md:"row"}} alignItems='center' bg='rgba(180, 224, 223, .2)' fontFamily='body' justifyContent='center' gap='2'>
        <Box
            gridColumn="1"
            gridRow="1"
            bg="#CFE4E4"
            borderRadius="full"
            w={{base:'20',md:"32"}}
            h={{base:'20',md:"32"}}                
            p={{base:'10',md:"20"}}
            fontSize={{base:'2xl',md:"7xl"}}
            display="flex"
            alignItems="center"
            justifyContent="center"                    
        >
            {number}
        </Box>
        <Box display='flex' flexDirection='column' w={{base:'80%', md:'60%'}} /* mr='10' */>
            <CardHeader display='flex' justifyContent='center' py='8' fontSize={{base:'xl',md:"4xl"}} textAlign='center'>
                {title}
            </CardHeader>
            <CardBody textAlign='center' mt='-12'>            
                <Text fontSize={{base:'lg',md:"xl"}} p='4'>{text}</Text>
            </CardBody>
        </Box>
    </Card>
  )
}

export default FAQCard