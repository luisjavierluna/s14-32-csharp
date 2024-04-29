import { Box, IconButton, HStack } from "@chakra-ui/react"
import { FaChevronLeft, FaChevronRight } from '../../assets/icons'
import { useState } from 'react'
import FAQCard from './FAQCard'

const FAQCarousel = () => {
  const faqs = [
    {
      id: 1,
      title: "¿Event Planner es gratis?",
      text: "Sí, crear eventos y contratar proveedores es gratis. Event Planner no cobrará nada por el servicio, solo abonarás al proveedor por el servicio contratado.",
    },
    {
      id: 2,
      title: "¿Cómo funciona?",
      text: "Solo tienes que crear tu evento, agregar puestos y ver presupuestos. Una vez que encuentras un presupuesto acorde a tus necesidades puedes contactar al proveedor y contratarlo.",
    },
    {
      id: 3,
      title: "¿Qué garantías me brinda Event Planner?",
      text: "Event Planner no interviene en las garantías ni condiciones de pago. Cada organizador debe acordar previamente con el proveedor.",
    },
    {
      id: 4,
      title: "¿Puedo contactar a un proveedor antes de contratarlo?",
      text: "Si. Event Planner te provee los datos de contacto del proveedor para que puedas hacerle consultas antes de contratar.",
    },
    {
      id: 5,
      title: "¿Qué información ven los expertos?",
      text: "Los expertos ven una ubicación aproximada al evento y no reciben datos de contacto hasta que el organizador decide que así sea.",
    }    
  ]

  const [currentIndex, setCurrentIndex] = useState(0)

  const nextSlide = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === faqs.length - 1 ? 0 : prevIndex + 1
    )
  }

  const prevSlide = () => {
    setCurrentIndex((prevIndex) =>
      prevIndex === 0 ? faqs.length - 1 : prevIndex - 1
    )
  }

  return (
        
      <Box position="relative" overflow="hidden" w="100%">
        <Box
          display="flex"
          transition="transform 0.3s ease-in-out"
          transform={`translateX(-${currentIndex * 100}%)`}
        >
          {faqs.map((faq) => (
            <Box key={faq.id} flex="0 0 100%" width="100%">
              <FAQCard number={faq.id} title={faq.title} text={faq.text} />
            </Box>
          ))}
        </Box>
        <HStack
          position="absolute"
          top="50%"
          transform="translateY(-50%)"
          left="0"
          right="0"
          justify="space-between"
          px="4"
        >
          <IconButton
            aria-label="Previous"
            icon={<FaChevronLeft />}
            onClick={prevSlide}
          />
          <IconButton
            aria-label="Next"
            icon={<FaChevronRight />}
            onClick={nextSlide}
          />
        </HStack>
      </Box>
    
  )
}

export default FAQCarousel
