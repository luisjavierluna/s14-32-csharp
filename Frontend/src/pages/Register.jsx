import { Container, Flex, Card, CardHeader, CardBody, CardFooter, Heading, Text, Image, AspectRatio, Link, CloseButton, Box, Center, Grid, Button, Input } from '@chakra-ui/react'
import { LoginButton, LoginInput, CancelAlert }  from '../components'
import { IoCheckmarkCircleOutline } from "../assets/icons"
import { useState } from 'react'
import * as Yup from 'yup'
import { useNavigate } from 'react-router-dom'
import axios from 'axios'

export default function Register () {  
  const [values, setValues] = useState({ email: '', password: '', password2: '', firstName: '', lastName: '', areacode: 0, phone: 0 })
  const [errors, setErrors] = useState('')
  const [phoneError, setPhoneError] = useState()
  const [isSubmitting, setIsSubmitting] = useState(false)
  const [showPassword, setShowPassword] = useState(false)
  const [showPassword2, setShowPassword2] = useState(false)
  const [imageUrl, setImageUrl] = useState('https://res.cloudinary.com/diclhd7dz/image/upload/v1714418751/utmkjhn0ecfxwtryghxn.png') 
  const navigate = useNavigate()

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
    firstName: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),
    lastName: Yup.string().min(3, 'Mínimo 3 caractares').max(20, 'Máximo 20 caracteres').required('Campo requerido'),
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
  const handleImgSubmit = async () => {
    const imageInput = document.querySelector('input[type="file"]')
    if (!imageInput || !imageInput.files || imageInput.files.length === 0) {
        console.error('No se ha seleccionado ningún archivo')
        console.log('No se ha seleccionado ningún archivo')
        return
    }  
    const imageUpload = imageInput.files[0]    
    try {          
        const formData = new FormData()
        formData.append('file', imageUpload)  
        const response = await axios.post('https://www.eventplanner.somee.com/api/ProfileImage', formData, {
            headers: {                
                'Content-Type': 'multipart/form-data',
            }
        })
        console.log(response.data)
        setImageUrl(response.data)
    } catch (error) {
        console.error('Error al subir imagen:', error.message)
    }
  }
  const handleSubmit = async (event) => {
    event.preventDefault()
    try {
      const phoneNumber = `${values.areacode}${values.phone}`
      if (phoneNumber.length > 10) {
        setPhoneError('La suma del código de área y el número de teléfono no puede superar los 10 caracteres')
        return                
      } else {
        setPhoneError('')      
        const newValues = { ...values, phone: phoneNumber }

        await validationSchema.validate(newValues, { abortEarly: false })
        setIsSubmitting(true)      
        console.log(newValues) 
        const requestBody = {
          email: newValues.email,
          firstName: newValues.firstName,
          lastName: newValues.lastName,
          password: newValues.password,
          confirmPassword: newValues.password2, 
          phoneNumber: newValues.phone, 
          profileImage: imageUrl,
        }
        console.log(requestBody)
        await axios.post('https://www.eventplanner.somee.com/api/Acounts/SignIn', requestBody)   
        console.log(requestBody)
        navigate('/login')
    }} catch (error) {
      const formErrors = {}
      if (error.inner) {
        error.inner.forEach((err) => {
          formErrors[err.path] = err.message
        })
      } else {
        formErrors.general = error.message
      }         
      setErrors(formErrors)      
    }
    setIsSubmitting(false)
  }
  return (
    <Container minW='100%' minH='100vh' padding='2' bg='rgba(180, 224, 223, .2)'>
      <AspectRatio maxW='150px' ratio={823 / 257}>
        <Link href='/'><Image src='logo2.png' alt='Logo Event Planner'/></Link>
      </AspectRatio>
      <Box display='flex' justifyContent='center' padding={{base:'2',sm:'10'}} >     
        <Card color='#263049' flexDirection='column' borderRadius='20' alignItems='center' width={{base:'100%', sm: '70%', md:'45%'}} boxShadow='xl'>          
          <CardHeader width='100%' display='flex' justifyContent='space-between' alignItems='center' position='relative'>
            <Center width='100%'>
              <Heading size='lg' fontFamily='heading'>CREAR CUENTA</Heading>
            </Center>
            <Link href='/'><CloseButton position='absolute' right={{base:'0.5rem',sm:'1rem'}} top='50%' transform='translateY(-50%)'  size={{base:'sm',sm:'lg'}} p='1'/></Link>
          </CardHeader>
          <CardBody width='90%' mt='-4' fontFamily='body'>
            <form onSubmit={handleSubmit}>
              <Box display='flex' flexDirection='column' gap='4'>         
                  <LoginInput id='email' name='Correo electrónico' type='text' placeholder='juanrodriguez@gmail.com' onChange={handleChange} errors={errors}/>
                  <LoginInput id='password' name='Contraseña' type={showPassword ? 'text' : 'password'} placeholder='Ingrese su contraseña' onChange={handleChange} errors={errors} togglePasswordVisibility={togglePasswordVisibility} showPassword={showPassword}/>
                  <LoginInput id='password2' name='Confirmar contraseña' type={showPassword2 ? 'text' : 'password'} placeholder='Vuelva a ingresar su contraseña' onChange={handleChange} errors={errors} togglePasswordVisibility={togglePasswordVisibility2} showPassword={showPassword2}/>                  
                  <Grid 
                  templateRows={{base:'repeat(1, 1fr)', lg:'repeat(2, 1fr)'}}
                  templateColumns={{base:'repeat(1, 1fr)', lg:'repeat(2, 1fr)'}}
                  gap={4}>
                      <LoginInput id='firstName' name='Nombre' type='text' placeholder='Juan' onChange={handleChange} errors={errors}/>
                      <LoginInput id='lastName' name='Apellido' type='text' placeholder='Rodriguez'onChange={handleChange} errors={errors}/>
                      <LoginInput id='areacode' name='Código de area' type='number' placeholder='011' onChange={handleChange} errors={errors}/>
                      <LoginInput id='phone' name='Teléfono' type='number' placeholder='46239758' onChange={handleChange} errors={errors}/>
                      {phoneError && (
                        <Text color="red.500" fontSize="sm">{phoneError}</Text>
                      )}
                  </Grid>
                  <Box display='flex' flexDirection={{base:'column', lg:'row'}}  justifyContent='center' alignItems='center' gap='4'>
                    <Button variant='outline' borderRadius='3xl' fontSize='xs' boxSize='fit-content' color='#CC949F' py='1' onClick={handleImgSubmit}>Cargar Foto</Button>
                    <Input placeholder='Seleccionar Archivo' size='sm' w='80%' type='file' accept=".jpg, .jpeg, .png, .webp"  border='none'/>
                    {imageUrl !== 'https://res.cloudinary.com/diclhd7dz/image/upload/v1714418751/utmkjhn0ecfxwtryghxn.png' &&
                    <Text color='#263049' borderWidth='2px' p='1' textAlign='center'>Imagen cargada correctamente</Text>}
                  </Box>
              </Box>
              <Box textAlign='center' mt='4'>
                <Flex alignItems='center' justifyContent='center'>
                  <IoCheckmarkCircleOutline size='20'/> 
                  <Text fontSize='xs' p='2' display='flex' flexDirection={{base:'column', md:'row'}} gap='1'>Acepto</Text>
                  <Text fontSize='xs' fontWeight='700' color='#263049' cursor='text'>términos y condiciones.</Text>  
                </Flex>
                <LoginButton bgcolor='#263049' color='white' name='Confirmar' isLoading={isSubmitting}/>
                {errors && <Text color='red'>Error al cargar usuario</Text>}                
                <Text fontSize='xs' p='2'>            
                    ¿Ya tienes una cuenta? {' '}
                    <Link fontSize='xs' fontWeight='700' color='#263049' href='/login'>Click aquí para iniciar sesión.</Link>         
                </Text> 
              </Box>
            </form> 
          </CardBody>
          <CardFooter flexDirection='column' gap='2' width='90%' alignItems='center' mt='-8'>            
            <CancelAlert navlink={'/'}/>
          </CardFooter>
        </Card>
      </Box>
  </Container>
  )
}
