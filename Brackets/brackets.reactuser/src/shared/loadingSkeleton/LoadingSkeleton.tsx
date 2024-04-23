//import { StyledLayoutBox } from "components/Layout/Layout.styles"

import {
    LoadingSkeletonContainer,
    //StyledEverDrivenLogo,
    //StyledLinearProgress
} from "./LoadingSkeleton.styles"

function LoadingSkeleton() {
    return (
        <StyledLayoutBox>
            <LoadingSkeletonContainer>
                {/*<StyledEverDrivenLogo />*/}
                {/*<StyledLinearProgress />*/}
            </LoadingSkeletonContainer>
        </StyledLayoutBox>
    )
}

export default LoadingSkeleton
