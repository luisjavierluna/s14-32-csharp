import { IconButton, Container, Card, CardHeader, CardBody, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, HStack, Center, Flex} from '@chakra-ui/react'
import LoginButton  from '../components/Login/LoginButton'
import LoginInput from '../components/Login/LoginInput'
import * as Yup from 'yup'
import { useState } from 'react'
import { FaEye, FaEyeSlash } from 'react-icons/fa'

export default function Login () { 
  const [values, setValues] = useState({ email: '', password: '' })
  const [errors, setErrors] = useState({})
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [showPassword, setShowPassword] = useState(false)

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword)
  }

  const validationSchema = Yup.object().shape({
    email: Yup.string().email('Correo electrónico inválido').required('Campo requerido'),
    password: Yup.string().required('Campo requerido')
  })

  const handleChange = (event) => {
    const { name, value } = event.target  
    setValues({
      ...values,
      [name]: value
    })
  }

  const handleSubmit = async (event) => {
    event.preventDefault()
    try {
      await validationSchema.validate(values, { abortEarly: false })
      setIsSubmitting(true)
      // Logica para enviar a backend
      console.log(values)
    } catch (error) {
      const formErrors = {}
      error.inner.forEach(err => {
        formErrors[err.path] = err.message;
      })
      setErrors(formErrors)
    }
    setIsSubmitting(false)
  } 

  return (
    <Container minW='100%' minH='100vh' padding='2' bg='rgba(180, 224, 223, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Image src='logo2.png' alt='Logo Event Planner'/>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding='10' >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='45%' boxShadow='xl' minH='600'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg'>INICIAR SESIÓN</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
          </CardHeader>
          <CardBody width='90%'>
          <form onSubmit={handleSubmit}>
            <HStack spacing='10' flexDirection='column' width=''>
              <LoginInput id='email' name='Correo electrónico' type='text' placeholder='Ingrese su correo electrónico' onChange={handleChange} errors={errors}/>
              <Box width='100%'>
                <Flex alignItems='end' justifyContent='center'>
                  <LoginInput id='password' name='Contraseña' type={showPassword ? 'text' : 'password'} placeholder='Ingrese su contraseña' onChange={handleChange} errors={errors}/>
                  <IconButton onClick={togglePasswordVisibility} mx='1' bg='white'>{showPassword ? <FaEye /> : <FaEyeSlash />}</IconButton>
                </Flex>
                <Text fontSize='xs' padding='2'>            
                    ¿Olvidaste tu contraseña? {' '}
                    <Link fontSize='xs' fontWeight='700' color='#263049' href='#'>Click aquí para recuperarla.</Link>         
                </Text>
              </Box>
              <Box mt='10' w='full' flexDirection='column' gap='2' alignItems='center' textAlign='center'>
                <LoginButton bgcolor='#263049' color='white' name='Confirmar' isLoading={isSubmitting} />
                <Text fontSize='xs' padding='2'>            
                  ¿No tienes una cuenta? {' '}
                  <Link fontSize='xs' fontWeight='700' color='#263049' href='/register'>Click aquí para registrarte.</Link>         
                </Text>
              </Box>
            </HStack>
            </form>
          </CardBody>          
        </Card>
      </Box>
  </Container>
  )
}

