// import { Container, Grid } from "@mui/material";
import { Button, ButtonGroup, Container } from '@mui/material';
import './Homepage.css';
import { FormPage } from './FormPage';
import { useState } from 'react';
import { DisplayAll } from './DisplayAll';

export function HomePage() {

    const [selection, setSelection] = useState(0);

    return (
        <Container>
            <ButtonGroup variant="contained" aria-label="Basic button group">
                <Button onClick={()=>setSelection(0)}>Display All</Button>
                <Button onClick={()=>setSelection(1)} color='success' >Create New Request</Button>
            </ButtonGroup>
            {selection == 0 ? <DisplayAll/> : <FormPage/>}
        </Container>)
}