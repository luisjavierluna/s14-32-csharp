import {
    FormControl,
    FormLabel,
    Input,
    FormErrorMessage,
    Box,
    IconButton  
} from '@chakra-ui/react'
import { FaEye, FaEyeSlash } from 'react-icons/fa'


export default function LoginInput({ id, name, type, placeholder, value, errors, onChange, togglePasswordVisibility, showPassword }) {
      
    return (
      <FormControl isInvalid={!!errors[id]}>
        <FormLabel>{name}:</FormLabel>
        <Box display='flex' alignItems='center'>
          <Input type={type} name={id} placeholder={placeholder} borderWidth='1px' borderColor='#263049' value={value} onChange={onChange}/>
          {id === 'password' || id === 'password2'
          ? 
          <IconButton onClick={togglePasswordVisibility} mx='1' bg='white'>{showPassword ? <FaEye /> : <FaEyeSlash />}</IconButton> 
          : 
          ''}
        </Box>
        <FormErrorMessage>{errors[id]}</FormErrorMessage> 
      </FormControl>
    )
}