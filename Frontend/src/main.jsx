import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import { store } from './store/store.js'
import { Provider } from 'react-redux'
import { ChakraProvider } from '@chakra-ui/react';
import { BrowserRouter } from 'react-router-dom';
import { extendTheme } from '@chakra-ui/react'
import '@fontsource-variable/roboto-condensed';
import '@fontsource-variable/league-spartan';

const theme = extendTheme({
  fonts: {
    heading: `'Roboto Condensed Variable', sans-serif`,
    body: `'League Spartan Variable', sans-serif`,
  },
})


ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <ChakraProvider theme={theme}>
      <Provider store={store}>
        <BrowserRouter>
          <App />
        </BrowserRouter>
      </Provider>
    </ChakraProvider>
  </React.StrictMode>,
)
