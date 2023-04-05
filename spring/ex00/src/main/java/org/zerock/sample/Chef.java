package org.zerock.sample;

import org.springframework.stereotype.Component;

import lombok.Data;

//	root-context.xml 에 설정이 되어 있어야 한다. (url 맵핑이 필요없는 경우) <annotation-driven /> <context:component-scan base-package="org.zerock" />
@Component
@Data			// vo 객체 같은 데이터 객체용
public class Chef {

}
