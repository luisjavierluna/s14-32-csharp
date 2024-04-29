import { Card, CardBody, CardHeader, Text } from "@chakra-ui/react"
import { HiStar } from '../../assets/icons'

const ReviewCard = ({text, stars}) => {

    const renderStars = () => {
        const starArray = []
        const starCount = Math.min(Math.max(stars, 1), 5)
        for (let i = 0; i < starCount; i++) {
          starArray.push(<HiStar key={i} />)
        }
        return starArray
      }

  return (
    <Card h='72' w='72' p='3' textAlign='center' borderRadius='3xl' bg='rgba(255, 255, 255, .8)' fontFamily='body'>
        <CardHeader display='flex' justifyContent='center' p='8'>
            {renderStars()}
        </CardHeader>
        <CardBody>
            <Text>{text}</Text>
        </CardBody>
    </Card>
  )
}

export default ReviewCard