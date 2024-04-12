import Home from './pages/Home/Home';
import EventForm from './pages/EventForm';
import Login from './pages/Login';
import Register from './pages/Register';
import { Route, Routes } from 'react-router';
import NavBar from './components/NavBar/NavBar';

function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route exact path='/login' element={<Login />}/>
        <Route exact path='/register' element={<Register />}/>
        <Route exact path='/eventform' element={<EventForm />}/>
        <Route exact path="/home" element={<Home />} />
      </Routes>
    </>
  );
}

export default App;
