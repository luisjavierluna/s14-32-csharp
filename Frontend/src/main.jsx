import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import { ChakraProvider } from '@chakra-ui/react'
import { BrowserRouter } from 'react-router-dom'
import { extendTheme } from '@chakra-ui/react'
import '@fontsource-variable/roboto-condensed'
import '@fontsource-variable/league-spartan'
import { UserAuthProvider } from './context/UserAuthContext.jsx'

const theme = extendTheme({
  fonts: {
    heading: `'Roboto Condensed Variable', sans-serif`,
    body: `'League Spartan Variable', sans-serif`,
  },
})


ReactDOM.createRoot(document.getElementById('root')).render( 
    <ChakraProvider theme={theme}> 
      <UserAuthProvider>    
        <BrowserRouter>
          <App />
        </BrowserRouter>  
      </UserAuthProvider>     
    </ChakraProvider>  
)
