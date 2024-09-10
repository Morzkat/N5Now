import './App.css'
import { Container } from '@mui/material';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PermissionPage from './pages/permissionPage';
import Layout from './components/layout';
import EmployeePage from './pages/EmployeePage';

function App() {
  return (
    <Container>
      <Router>
        <Routes>
          <Route path='/' element={<Layout />}>
            <Route index element={<PermissionPage />} />
            <Route path='/permissions' element={<PermissionPage />} />
            <Route path='/employees' element={<EmployeePage />} />
          </Route>
          {/* <Route path="/permission/:action/:id" element={<PermissionDetail />} /> */}
        </Routes>
      </Router>
    </Container>
  )
}

export default App
