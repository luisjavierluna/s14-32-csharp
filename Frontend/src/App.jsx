import Landing from './pages/Landing'
import EventForm from './pages/EventForm'
import Login from './pages/Login'
import Register from './pages/Register'
import { Route, Routes } from 'react-router'
import { NavBar, Footer } from './components'
import { useLocation } from 'react-router-dom'
import UserDashboard from './pages/UserDashboard'
import ContractorForm from './pages/ContractorForm'
import EventInfoCard from './pages/EventInfoCard'
import PostulableEvents from './pages/PostulableEvents'

function App() {
  const location = useLocation();  
  const hideNavBarRoutes = ['/login', '/register', '/eventform', '/eventinfocard']
  const isNavBarHidden = hideNavBarRoutes.includes(location.pathname)

  return (
    <>     
      {!isNavBarHidden && <NavBar />}
      <Routes>
        <Route exact path='/login' element={<Login />}/>
        <Route exact path='/register' element={<Register />}/>
        <Route exact path='/eventform' element={<EventForm />}/> 
        <Route path='/' element={<Landing />}/>
        <Route exact path='/userdashboard' element={<UserDashboard />}/>
        <Route exact path='/contractorform' element={<ContractorForm />}/>
        <Route path='/eventinfocard/:id' element={<EventInfoCard />}/>  
        <Route exact path='/postulableevents' element={<PostulableEvents />}/>            
      </Routes>
      {!isNavBarHidden && <Footer/>}      
    </>
  );
}


export default App