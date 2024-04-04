import { Container, Card, CardHeader, CardBody, CardFooter, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, Center, Grid, IconButton, Popover, PopoverTrigger, PopoverContent, PopoverHeader, PopoverArrow, PopoverCloseButton, PopoverBody, PopoverFooter, ButtonGroup, Button} from '@chakra-ui/react'
import LoginButton  from '../components/Login/LoginButton'
import LoginInput from '../components/Login/LoginInput'
import { CheckIcon, DeleteIcon } from '@chakra-ui/icons'

export default function Register () {  
  return (
    <Container minW='100%' minH='100vh' padding='2' bg='rgba(157, 213, 212, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Image src='logo2.png' alt='Logo Event Planner'/>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding='10' >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='50%' boxShadow='xl'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg'>CREAR CUENTA</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
          </CardHeader>
          <CardBody width='90%'>
            <Box display='flex' flexDirection='column' gap='4'>         
                <LoginInput id='email' name='Correo electrónico' type='text' placeholder='juanrodriguez@gmail.com' />              
                <LoginInput id='password' name='Contraseña' type='text' placeholder='Ingrese su contraseña' />
                <LoginInput id='password2' name='Confirmar contraseña' type='text' placeholder='Vuelva a ingresar su contraseña' />
                <Grid 
                templateRows='repeat(2, 1fr)'
                templateColumns='repeat(2, 1fr)'
                gap={4}>
                    <LoginInput id='name' name='Nombre' type='text' placeholder='Juan' />
                    <LoginInput id='lastname' name='Apellido' type='text' placeholder='Rodriguez' />
                    <LoginInput id='areacode' name='Código de area' type='number' placeholder='011' />
                    <LoginInput id='phone' name='Teléfono' type='number' placeholder='46239758' />
                </Grid>
            </Box>  
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center'>
            <Text fontSize='xs' padding='2'> 
                <IconButton
                  isRound={true}
                  variant='outline'                  
                  aria-label='Done'
                  colorScheme='#263049'
                  size='xs'
                  marginX='1'                  
                  icon={<CheckIcon />}
                />           
                Acepto {' '}
                <Link fontSize='xs' fontWeight='700' color='#263049' href='#'>términos y condiciones.</Link>         
            </Text>
            <LoginButton bgcolor='#263049' color='white' name='Confirmar'/>
            <Text fontSize='xs' padding='2'>            
                ¿Ya tienes una cuenta? {' '}
                <Link fontSize='xs' fontWeight='700' color='#263049' href='/login'>Click aquí para iniciar sesión.</Link>         
            </Text>          
            <Popover              
              placement='bottom'
              closeOnBlur={false}
            >
              <PopoverTrigger>
                <IconButton
                  isRound={true}
                  variant='solid'
                  bgColor='rgba(224, 7, 7, .47)'
                  color='white'
                  aria-label='Done'
                  size='md'
                  icon={<DeleteIcon />}
                />
              </PopoverTrigger>
              <PopoverContent color='white' bg='blue.800' borderColor='blue.800'>
                <PopoverHeader pt={4} fontWeight='bold' border='0'>
                  ¿Desea cancelar el registro?
                </PopoverHeader>
                <PopoverArrow bg='blue.800' />
                <PopoverCloseButton />
                <PopoverBody>
                  Se perderán todos los datos y deberá volver a cargarlos.
                </PopoverBody>
                <PopoverFooter
                  border='0'
                  display='flex'
                  alignItems='center'
                  justifyContent='center'
                  pb={4}>                  
                    <ButtonGroup size='sm'>
                      <Link href='/'><Button bgColor='#E00707' color='white'>Cancelar Registro</Button></Link>                      
                    </ButtonGroup>
                </PopoverFooter>
              </PopoverContent>
            </Popover>
          </CardFooter>
        </Card>
      </Box>
  </Container>
  )
}
