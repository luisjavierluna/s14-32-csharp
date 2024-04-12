import EventForm from './pages/EventForm';
import Login from './pages/Login';
import Register from './pages/Register';
import { Route, Routes } from 'react-router';

function App() {
  return (
    <>
      <Routes>
        <Route exact path='/login' element={<Login />}/>
        <Route exact path='/register' element={<Register />}/>
        <Route exact path='/eventform' element={<EventForm />}/>
      </Routes>
    </>
  )
}

export default App;
