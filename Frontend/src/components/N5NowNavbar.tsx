import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import { Link } from 'react-router-dom';

const pages = ['permissions', 'employees'];

const linkStyle = {
    textDecoration: "none",
    color: "white",
    fontSize: "20px",
    marginLeft: 20,
    "&:hover": {
        color: "yellow",
        borderBottom: "1px solid white",
    },
};

function N5NowNavbar() {
    return (
        <AppBar position="static">
            <Container maxWidth="xl">
                <Toolbar disableGutters>
                    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                        {pages.map((page) => (
                            <Link to={`/${page}`} style={linkStyle} key={page}>
                                {page}
                            </Link>
                        ))}
                    </Box>
                </Toolbar>
            </Container>
        </AppBar>
    );
}
export default N5NowNavbar;
