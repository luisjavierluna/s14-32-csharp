import { Button } from "@chakra-ui/react";


export default function LoginButton ({color, bgcolor, name}) {
  return (
    <Button bg={bgcolor} color={color} borderRadius='20' width='100%' fontSize='1.2rem' padding='6'>{name} </Button>
  )
}