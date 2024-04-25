import { Box, Image, Link } from "@chakra-ui/react"
import FooterLogo from '../../assets/footer.png'
import { FaLinkedin, FaInstagram, FaGithub, MdMailOutline } from '../../assets/icons'

const Footer = () => {
  return (
    <Box display='flex' justifyContent='space-between' alignItems='center' p='2' h='10vh' w='100%'>
        <Link href='/'><Image src={FooterLogo} alt='Footer Logo' boxSize='14'></Image></Link>
        <Link href='https://www.gmail.com/' target='_blank' display={{base:'none', sm:'block'}}>consultas@eventplanner.com</Link>
        <Box display='flex' gap='2'>
          <Link href='https://www.gmail.com/' target='_blank' display={{base:'block', sm:'none'}}><MdMailOutline size='28' /></Link>
          <Link href='https://www.linkedin.com/' target='_blank'><FaLinkedin size='28' /></Link>
          <Link href='https://www.github.com/' target='_blank'><FaGithub size='28'/></Link>
          <Link href='https://www.instagram.com/' target='_blank'><FaInstagram size='28'/></Link>
        </Box>
    </Box>
  )
}

export default Footer