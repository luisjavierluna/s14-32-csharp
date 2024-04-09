import { IconButton, Container, Flex, Card, CardHeader, CardBody, CardFooter, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, Center, Grid } from '@chakra-ui/react'
import LoginButton  from '../components/Login/LoginButton'
import LoginInput from '../components/Login/LoginInput'
import { IoCheckmarkCircleOutline } from "react-icons/io5"
import CancelAlert from '../components/Login/CancelAlert'
import { useState } from 'react'
import * as Yup from 'yup'
import { FaEye, FaEyeSlash } from 'react-icons/fa'

export default function Register () {  
  const [values, setValues] = useState({ email: '', password: '', password2: '', firstname: '', lastname: '', areacode: 0, phone: 0 })
  const [errors, setErrors] = useState({})
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [showPassword, setShowPassword] = useState(false)
  const [showPassword2, setShowPassword2] = useState(false)

  const validationSchema = Yup.object().shape({
    email: Yup.string().email('Correo electrónico inválido').required('Campo requerido'),
    password: Yup.string().min(8, 'La contraseña debe tener mínimo 8 caracteres')
      .matches(
        /^(?=.*[a-z])/,
        'Debe contener al menos una letra en minúscula'
      )
      .matches(
        /^(?=.*[A-Z])/,
        'Debe contener al menos una letra en mayúscula'
      )
      .matches(
        /^(?=.*[0-9])/,
        'Debe contener al menos un número'
      )
      .matches(
        /^(?=.*[!@#/$%/^&/*])/,
        'Debe contener al menos un caracter especial'
      )
      .required('Campo requerido'),
    password2: Yup.string().oneOf([Yup.ref('password')], 'Las contraseñas no coinciden').required('Campo requerido'),
    firstname: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),
    lastname: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),
    areacode: Yup.number().min(2, 'Mínimo 2 caractares').required('Campo requerido'),
    phone: Yup.number().min(5, 'Mínimo 5 caractares').required('Campo requerido'),
  })

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword)
  }
  const togglePasswordVisibility2 = () => {
    setShowPassword2(!showPassword2)
  }

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
      const phoneNumber = `${values.areacode}${values.phone}`
      const newValues = { ...values, phone: phoneNumber }

      await validationSchema.validate(newValues, { abortEarly: false })
      setIsSubmitting(true)
      // Logica para enviar a backend
      console.log(newValues)      
    } catch (error) {
      const formErrors = {}
      error.inner.forEach(err => {
        formErrors[err.path] = err.message
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
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width='45%' boxShadow='xl'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg' fontFamily='heading'>CREAR CUENTA</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right='1rem' top='50%' transform='translateY(-50%)' size='lg'/></Link>
          </CardHeader>
          <CardBody width='90%' mt='-4' fontFamily='body'>
            <form onSubmit={handleSubmit}>
              <Box display='flex' flexDirection='column' gap='4'>         
                  <LoginInput id='email' name='Correo electrónico' type='text' placeholder='juanrodriguez@gmail.com' onChange={handleChange} errors={errors}/>
                  <Box display='flex' alignItems='end' justifyContent='center'>              
                    <LoginInput id='password' name='Contraseña' type={showPassword ? 'text' : 'password'} placeholder='Ingrese su contraseña' onChange={handleChange} errors={errors}/> 
                    <IconButton onClick={togglePasswordVisibility} mx='1' bg='white'>{showPassword ? <FaEye /> : <FaEyeSlash />}</IconButton>
                  </Box>
                  <Box display='flex' alignItems='end' justifyContent='center'>
                    <LoginInput id='password2' name='Confirmar contraseña' type={showPassword2 ? 'text' : 'password'} placeholder='Vuelva a ingresar su contraseña' onChange={handleChange} errors={errors} />
                    <IconButton onClick={togglePasswordVisibility2} mx='1' bg='white'>{showPassword2 ? <FaEye /> : <FaEyeSlash />}</IconButton>
                  </Box>
                  <Grid 
                  templateRows={{base:'repeat(1, 1fr)', lg:'repeat(2, 1fr)'}}
                  templateColumns={{base:'repeat(1, 1fr)', lg:'repeat(2, 1fr)'}}
                  gap={4}>
                      <LoginInput id='firstname' name='Nombre' type='text' placeholder='Juan' onChange={handleChange} errors={errors}/>
                      <LoginInput id='lastname' name='Apellido' type='text' placeholder='Rodriguez'onChange={handleChange} errors={errors}/>
                      <LoginInput id='areacode' name='Código de area' type='number' placeholder='011' onChange={handleChange} errors={errors}/>
                      <LoginInput id='phone' name='Teléfono' type='number' placeholder='46239758' onChange={handleChange} errors={errors}/>
                  </Grid>
              </Box>
              <Box textAlign='center' mt='4'>
                <Flex alignItems='center' justifyContent='center'>
                  <IoCheckmarkCircleOutline size='20'/> 
                  <Text fontSize='xs' p='2'>                                         
                      Acepto {' '}
                      <Link fontSize='xs' fontWeight='700' color='#263049' href='#'>términos y condiciones.</Link>         
                  </Text>
                </Flex>
                <LoginButton bgcolor='#263049' color='white' name='Confirmar' isLoading={isSubmitting}/>
                <Text fontSize='xs' p='2'>            
                    ¿Ya tienes una cuenta? {' '}
                    <Link fontSize='xs' fontWeight='700' color='#263049' href='/login'>Click aquí para iniciar sesión.</Link>         
                </Text> 
              </Box>
            </form> 
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center' mt='-8'>            
            <CancelAlert />
          </CardFooter>
        </Card>
      </Box>
  </Container>
  )
}
