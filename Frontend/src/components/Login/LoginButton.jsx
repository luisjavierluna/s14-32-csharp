import { Button } from "@chakra-ui/react";


export default function LoginButton ({color, bgcolor, name, isLoading}) {
  return (
    <Button type="submit" isLoading={isLoading} bg={bgcolor} color={color} borderRadius='20' width='100%' fontSize='1.2rem' padding='4'>{name} </Button>
  )
}