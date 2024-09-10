import * as React from 'react';
import { Employee } from '../models/employee';
import { useState, useEffect, FormEvent } from 'react';
import { createEmployee, getAllEmployees, updateEmployee } from '../services/employeesService';
import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Select, SelectChangeEvent, TextField } from '@mui/material';


export default function EmployeeForm({ employee }: { employee?: Employee }) {
    const [name, setName] = useState(employee?.name || '');
    const [lastName, setLastName] = useState(employee?.lastName || '');

    const [isNewEmployee, setIsNewEmployee] = useState(true);

    useEffect(() => {

        if (employee) setIsNewEmployee(false);

    }, []);

    const handleNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleLastNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setLastName(event.target.value);
    };

    const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const payload: Employee = {
            name,
            lastName,
        };

        if (isNewEmployee) {
            const response = await createEmployee(payload);
        }
        else {
            payload.id = employee?.id;
            const response = await updateEmployee(payload);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <Box sx={{ mx: 'auto', width: 400 }}>

                <TextField
                    label="Name"
                    value={name}
                    onChange={handleNameChange}
                    fullWidth
                    margin="normal"
                />

                <TextField
                    label="Last Name"
                    value={lastName}
                    onChange={handleLastNameChange}
                    fullWidth
                    margin="normal"
                />

                <Button type="submit" variant="contained" color="primary">
                    {isNewEmployee ? 'Create Employee' : 'Update Employee'}
                </Button>

            </Box>
        </form>
    );
}
