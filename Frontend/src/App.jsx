import Home from './pages/Home/Home';
import Login from './pages/Login';
import { Route, Routes } from 'react-router';
import NavBar from './components/NavBar/NavBar';
function App() {
  return (
    <>
      <NavBar />
      <Routes>
        <Route path="/" element={<Login />} />
        <Route exact path="/home" element={<Home />} />
      </Routes>
    </>
  );
}

export default App;
