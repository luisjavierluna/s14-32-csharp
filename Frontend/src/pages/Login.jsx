import { Container, Card, CardHeader, CardBody, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, HStack, Center } from '@chakra-ui/react'
import { LoginButton, LoginInput, ForgotPasswordAlert }  from '../components'
import * as Yup from 'yup'
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import axios from 'axios'
import { useUserAuth } from '../context/UserAuthContext'

export default function Login () { 
  const [values, setValues] = useState({ email: '', password: '' })
  const [errors, setErrors] = useState({})
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [showPassword, setShowPassword] = useState(false)
  const navigate = useNavigate()
  const { handleLogin } = useUserAuth()

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
      console.log(values)
      const response = await axios.post('https://www.eventplanner.somee.com/api/Acounts/Login', values)
      console.log(response.data)
      await handleLogin(response.data)      
      navigate('/userdashboard')   
    } catch (error) {
      const formErrors = {}
      if (error.inner) {
      error.inner.forEach(err => {
        formErrors[err.path] = err.message;
      })
      setErrors(formErrors)
    } else {
      console.error('Error desconocido:', error.message);
    }
    }
    setIsSubmitting(false)
  } 

  return (
    <Container minW='100%' minH='100vh' padding='2' bg='rgba(180, 224, 223, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Link href='/'><Image src='logo2.png' alt='Logo Event Planner'/></Link>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding={{base:'2',sm:'10'}} >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width={{base:'100%', sm: '70%', md:'45%'}} boxShadow='xl' minH='600'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg' fontFamily='heading'>INICIAR SESIÓN</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right={{base:'0.5rem',sm:'1rem'}} top='50%' transform='translateY(-50%)' size={{base:'sm',sm:'lg'}} p='1'/></Link>
          </CardHeader>
          <CardBody width='90%' fontFamily='body'>
          <form onSubmit={handleSubmit}>
            <HStack spacing='10' flexDirection='column' width=''>
              <LoginInput id='email' name='Correo electrónico' type='text' placeholder='Ingrese su correo electrónico' onChange={handleChange} errors={errors}/>
              <Box width='100%'>                
                <LoginInput id='password' name='Contraseña' type={showPassword ? 'text' : 'password'} placeholder='Ingrese su contraseña' onChange={handleChange} errors={errors} togglePasswordVisibility={togglePasswordVisibility} showPassword={showPassword} />
                <Text fontSize='xs' padding='2'>            
                    ¿Olvidaste tu contraseña? {' '}                    
                    <ForgotPasswordAlert />       
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

