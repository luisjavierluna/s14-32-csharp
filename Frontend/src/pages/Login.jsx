import { Container, Card, CardHeader, CardBody, CardFooter, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, HStack, Center} from '@chakra-ui/react'
import LoginButton  from '../components/Login/LoginButton'
import LoginInput from '../components/Login/LoginInput'

export default function Login () {
  return (
    <Container minW='100%' minH='100vh' padding='2' bg='rgba(157, 213, 212, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Image src='logo2.png' alt='Logo Event Planner'/>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding='10' >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='50%' boxShadow='xl' minH='600'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg'>INICIAR SESIÓN</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
          </CardHeader>
          <CardBody width='90%'>
            <HStack spacing='10' flexDirection='column' width=''>
              <LoginInput id='email' name='Correo electrónico' type='text' placeholder='Ingrese su correo electrónico' />
              <Box width='100%'>
                <LoginInput id='password' name='Contraseña' type='text' placeholder='Ingrese su contraseña' />
                <Text fontSize='xs' padding='2'>            
                    ¿Olvidaste tu contraseña? {' '}
                    <Link fontSize='xs' fontWeight='700' color='#263049' href='#'>Click aquí para recuperarla.</Link>         
                </Text>
              </Box>
            </HStack>
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center' paddingY='10'>
            <LoginButton bgcolor='#263049' color='white' name='Confirmar'/>
            <Text fontSize='xs' padding='2'>            
                ¿No tienes una cuenta? {' '}
                <Link fontSize='xs' fontWeight='700' color='#263049' href='/register'>Click aquí para registrarte.</Link>         
            </Text>
          </CardFooter>
        </Card>
      </Box>
  </Container>
  )
}

