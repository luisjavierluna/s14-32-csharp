import {
    FormControl,
    FormLabel,
    Input,
    FormErrorMessage    
} from '@chakra-ui/react'


export default function LoginInput({ id, name, type, placeholder, value, errors, onChange }) {
      
    return (
      <FormControl isInvalid={!!errors[id]}>
        <FormLabel>{name}:</FormLabel>
        <Input type={type} name={id} placeholder={placeholder} borderWidth='1px' borderColor='#263049' value={value} onChange={onChange}/>
        <FormErrorMessage>{errors[id]}</FormErrorMessage> 
      </FormControl>
    )
}