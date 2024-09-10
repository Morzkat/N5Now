import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { useEffect, useState } from 'react';
import BorderColorIcon from '@mui/icons-material/BorderColor';
import N5NowModal from '../components/N5NowModal';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button } from '@mui/material';
import { deleteEmployee, getAllEmployees } from '../services/employeesService';
import { Employee } from '../models/employee';
import EmployeeForm from '../components/EmployeeForm';
import { ToastContainer } from 'react-toastify';
import * as toastService from './../services/toastService';

export default function EmployeePage() {

    const [employees, setEmployees] = useState<Employee[]>([]);

    const fetchEmployees = async () => {
        try {
            const response = await getAllEmployees();
            setEmployees(response);
        } catch (error) {
            console.error(error);
        }
    }

    async function handleDeleteEmployee(employeeId: number | undefined) {
        try {
            const deleted = await deleteEmployee(employeeId);
            if (deleted) {
                toastService.success('Permission deleted it.')
                fetchEmployees();
            }
            else
                toastService.error('Error deleting permission.')

        } catch (error) {
            toastService.error('Error deleting permission.')
            console.error(error);
        }
    }

    useEffect(() => {
        fetchEmployees();
    }, []);

    return (
        <>
            <N5NowModal openModalTag={<p>Add Employee</p>} content={<EmployeeForm callback={fetchEmployees} />} />
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 1050 }} aria-label="simple table">
                    <TableHead>
                        <TableRow>
                            <TableCell align="right">Id</TableCell>
                            <TableCell align="right">Name</TableCell>
                            <TableCell align="right">Last Name</TableCell>
                            <TableCell align="right">Actions</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {employees.map((employee) => (
                            <TableRow
                                key={employee.id}
                                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                            >
                                <TableCell align="right" component="th" scope="row"> {employee.id} </TableCell>
                                <TableCell align="right">{employee.name}</TableCell>
                                <TableCell align="right">{employee.lastName}</TableCell>
                                <TableCell align="right" >
                                    <N5NowModal openModalTag={<BorderColorIcon />} content={<EmployeeForm employee={employee} callback={fetchEmployees} />} />
                                    <Button onClick={async () => await handleDeleteEmployee(employee.id)}><DeleteIcon /></Button>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </TableContainer>
            <ToastContainer />
        </>

    );
}