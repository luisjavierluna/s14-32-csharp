import {
    FormControl,
    FormLabel,
    Input
} from '@chakra-ui/react'


export default function LoginInput({ id, name, type, placeholder, value }) {
      
    return (
      <FormControl isRequired>
        <FormLabel>{name}:</FormLabel>
        <Input type={type} name={id} placeholder={placeholder} borderWidth='1px' borderColor='#263049'/> 
      </FormControl>
    )
}