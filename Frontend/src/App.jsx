import Landing from './pages/Landing'
import EventForm from './pages/EventForm'
import Login from './pages/Login'
import Register from './pages/Register'
import { Route, Routes } from 'react-router'
import { NavBar, Footer } from './components'
import { useLocation } from 'react-router-dom'
import UserDashboard from './pages/UserDashboard'
import ContractorForm from './pages/ContractorForm'

function App() {
  const location = useLocation();  
  const hideNavBarRoutes = ['/login', '/register', '/eventform']
  const isNavBarHidden = hideNavBarRoutes.includes(location.pathname)

  return (
    <>     
      {!isNavBarHidden && <NavBar />}
      <Routes>
        <Route exact path='/login' element={<Login />}/>
        <Route exact path='/register' element={<Register />}/>
        <Route exact path='/eventform' element={<EventForm />}/> 
        <Route exact path="/" element={<Landing />}/>
        <Route exact path="/userdashboard" element={<UserDashboard />}/>
        <Route exact path="/contractorform" element={<ContractorForm />}/>                 
      </Routes>
      {!isNavBarHidden && <Footer/>}      
    </>
  );
}


export default App