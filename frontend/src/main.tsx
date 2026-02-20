import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.tsx'
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ToastContainer } from 'react-toastify';

const queryClient = new QueryClient(); 

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <QueryClientProvider client={queryClient}>
      <ToastContainer position='top-right' hideProgressBar theme='colored'/>
      <App />
    </QueryClientProvider>
  </StrictMode>,
)
