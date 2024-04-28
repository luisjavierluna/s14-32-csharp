import { Box, Flex, Text, Button, Stack, Image } from '@chakra-ui/react'
import { useState } from 'react'
import Logo from '../../assets/Logo.png'
import { useUserAuth } from '../../context/UserAuthContext'
import { Link } from 'react-router-dom'

const NavBar = (props) => {  
  const [isOpen, setIsOpen] = useState(false)  

  const toggle = () => setIsOpen(!isOpen);

  return (
    <NavBarContainer {...props}>
      <Link to={'/'}><Image src={Logo} alt="logo" w='44' h='auto'/></Link>
      <MenuToggle toggle={toggle} isOpen={isOpen} />
      <MenuLinks isOpen={isOpen} toggle={toggle} />
    </NavBarContainer>
  );
};

const CloseIcon = () => (
  <svg width="24" viewBox="0 0 18 18" xmlns="http://www.w3.org/2000/svg">
    <title>Close</title>
    <path
      fill="#263049"
      d="M9.00023 7.58599L13.9502 2.63599L15.3642 4.04999L10.4142 8.99999L15.3642 13.95L13.9502 15.364L9.00023 10.414L4.05023 15.364L2.63623 13.95L7.58623 8.99999L2.63623 4.04999L4.05023 2.63599L9.00023 7.58599Z"
    />
  </svg>
);

const MenuIcon = () => (
  <svg
    width="24px"
    viewBox="0 0 20 20"
    xmlns="http://www.w3.org/2000/svg"
    fill="#263049"
  >
    <title>Menu</title>
    <path d="M0 3h20v2H0V3zm0 6h20v2H0V9zm0 6h20v2H0v-2z" />
  </svg>
);

const MenuToggle = ({ toggle, isOpen }) => {
  return (
    <Box display={{ base: 'block', md: 'none' }} onClick={toggle}>
      {isOpen ? <CloseIcon /> : <MenuIcon />}
    </Box>
  );
};

const MenuItem = ({ children, isLast, to = '/', toggle, ...rest }) => {
  return (
    <Link to={to} onClick={toggle}>
      <Text display="block" {...rest}>
        {children}
      </Text>
    </Link>
  );
};

const MenuLinks = ({ isOpen, toggle }) => {
  const { handleLogout } = useUserAuth()
  const token = localStorage.getItem('token') ? localStorage.getItem('token') : '' 
  return (
    <Box
      display={{ base: isOpen ? 'block' : 'none', md: 'block' }}
      flexBasis={{ base: '100%', md: 'auto' }}
      bg='white'    
      m='-3'      
    >
      { token ?
      (<Stack
        spacing={1}
        align="center"
        justify={['center', 'space-between', 'flex-end', 'flex-end']}
        direction={['column', 'column', 'row']}
        py={{base:'4', md:'0'}}
        minW={{base:'100vw', md:'50vh'}}>
        <MenuItem to="/userdashboard" isLast toggle={toggle}>
          <Button
            size="sm"
            rounded="50px"
            w="119px"
            h="25px"            
            color={['#263049']}
            variant='ghost'            >
            Mi Cuenta
          </Button>
        </MenuItem>
        <MenuItem to="/" isLast toggle={toggle}>
          <Button
            size="sm"
            rounded="50px"
            w="119px"
            h="25px"            
            color={['#263049']}
            fontWeight='300'
            variant='ghost'
            onClick={handleLogout}>
            Cerrar Sesión
          </Button>
        </MenuItem>
        </Stack>)
        :
        (<Stack
        spacing={8}
        align="center"
        justify={['center', 'space-between', 'flex-end', 'flex-end']}
        direction={['column', 'column', 'row']}
        py={{base:'4', md:'0'}}
        minW={{base:'100vw', md:'50vh'}}>
          <MenuItem to="/register" isLast toggle={toggle}>
            <Button
              size="sm"
              rounded="50px"
              w="119px"
              h="25px"
              border="1px solid"
              borderColor="#263049"
              color={['#263049']}
              bg={'#fff'}
              boxShadow='xl'>
              Crear Cuenta
            </Button>
          </MenuItem>
          <MenuItem to="/login" isLast toggle={toggle}>
            <Button
              size="sm"
              rounded="50px"
              w="119px"
              h="25px"
              color="#fff"
              bg={'#263049'}
              boxShadow='xl'>
              Iniciar Sesión
            </Button>
          </MenuItem>
          </Stack>)
        }
    </Box>
  );
};

const NavBarContainer = ({ children, ...props }) => {
  return (
    <Flex
      as="nav"
      align="center"
      justify="space-between"
      wrap="wrap"
      w="100%"
      h={{md:"10vh"}}
      mb={0}      
      px={3}
      pr={9}      
      color={['black']}
      {...props}
    >
      {children}
    </Flex>
  );
};

export default NavBar;
