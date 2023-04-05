package org.zerock.sample;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import lombok.Data;
import lombok.Setter;

//root-context.xml 에 설정이 되어 있어야 한다. (url 맵핑이 필요없는 경우) <annotation-driven /> <context:component-scan base-package="org.zerock" />
@Component
@Data			// vo 객체 같은 데이터 객체용
public class Restaurant {
	
	// @Inject - Java 에 DI 적용할때, @Autowired - Spring 라이브러리, @Setter- Lombok 라이브러리 : Spring Autowired 를 사용한다.
	@Setter(onMethod_ = @Autowired)
	private Chef chef;

}
