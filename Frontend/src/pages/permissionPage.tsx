import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import { Permission } from '../models/permission';
import { useEffect, useState } from 'react';
import { getAllPermissions } from '../services/permissionService';
import BorderColorIcon from '@mui/icons-material/BorderColor';

export default function PermissionPage() {

  const [permissions, setPermissions] = useState<Permission[]>([]);

  async function fetchPermissions() {
    try {
      const response = await getAllPermissions();
      setPermissions(response);
    } catch (error) {
      console.error(error);
    }
  }

  useEffect(() => {
    fetchPermissions();
  }, []);

  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 1050 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell align="right">Id</TableCell>
            <TableCell align="right">Name</TableCell>
            <TableCell align="right">Last Name</TableCell>
            <TableCell align="right">Permission Type</TableCell>
            <TableCell align="right">Date</TableCell>
            <TableCell align="right">Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {permissions.map((permission) => (
            <TableRow
              key={permission.id}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell align="right" component="th" scope="row"> {permission.id} </TableCell>
              <TableCell align="right">{permission.name}</TableCell>
              <TableCell align="right">{permission.lastName}</TableCell>
              <TableCell align="right">{permission.permissionType.description}</TableCell>
              <TableCell align="right">{permission.date?.toString()}</TableCell>
              <TableCell align="right" ><BorderColorIcon /></TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
}